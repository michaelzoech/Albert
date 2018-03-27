using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DrawNormals : MonoBehaviour {
#if UNITY_EDITOR

    [SerializeField]
    private MeshFilter meshFilter = null;
    [SerializeField]
    private bool displayWireframe = false;
    [SerializeField]
    private NormalsDrawData faceNormals = new NormalsDrawData(new Color32(34, 221, 221, 155), true);
    [SerializeField]
    private NormalsDrawData vertexNormals = new NormalsDrawData(new Color32(200, 255, 195, 127), true);

    [System.Serializable]
    private class NormalsDrawData {

        private enum DrawType { Never, Selected, Always }

        [SerializeField]
        private DrawType draw = DrawType.Selected;
        [SerializeField]
        private float length = 0.3f;
        [SerializeField]
        private Color normalColor;
        private Color baseColor = new Color32(255, 133, 0, 255);
        private const float baseSize = 0.0125f;

        public NormalsDrawData(Color normalColor, bool draw) {
            this.normalColor = normalColor;
            this.draw = draw ? DrawType.Selected : DrawType.Never;
        }

        public bool CanDraw(bool isSelected) {
            return (draw == DrawType.Always) || (draw == DrawType.Selected && isSelected);
        }

        public void Draw(Vector3 from, Vector3 direction) {
            if (Camera.current.transform.InverseTransformDirection(direction).z < 0f) {
                Gizmos.color = baseColor;
                Gizmos.DrawWireSphere(from, baseSize);

                Gizmos.color = normalColor;
                Gizmos.DrawRay(from, direction * length);
            }
        }
    }

    void OnDrawGizmosSelected() {
        EditorUtility.SetSelectedRenderState(GetComponent<Renderer>(), displayWireframe ? EditorSelectedRenderState.Wireframe : EditorSelectedRenderState.Highlight);
        OnDrawNormals(true);
    }

    void OnDrawGizmos() {
        if (!Selection.Contains(this)) {
            OnDrawNormals(false);
        }
    }

    private void OnDrawNormals(bool isSelected) {
        if (meshFilter == null) {
            meshFilter = GetComponent<MeshFilter>();
            if (meshFilter == null) {
                return;
            }
        }

        Mesh mesh = meshFilter.sharedMesh;

        if (faceNormals.CanDraw(isSelected)) {
            int[] triangles = mesh.triangles;
            Vector3[] vertices = mesh.vertices;

            for (int i = 0; i < triangles.Length; i += 3) {
                Vector3 v0 = transform.TransformPoint(vertices[triangles[i]]);
                Vector3 v1 = transform.TransformPoint(vertices[triangles[i + 1]]);
                Vector3 v2 = transform.TransformPoint(vertices[triangles[i + 2]]);
                Vector3 center = (v0 + v1 + v2) / 3;

                Vector3 dir = Vector3.Normalize(Vector3.Cross(v1 - v0, v2 - v0));

                faceNormals.Draw(center, dir);
            }
        }

        if (vertexNormals.CanDraw(isSelected)) {
            Vector3[] vertices = mesh.vertices;
            Vector3[] normals = mesh.normals;
            for (int i = 0; i < vertices.Length; i++) {
                vertexNormals.Draw(transform.TransformPoint(vertices[i]), Vector3.Normalize(transform.TransformVector(normals[i])));
            }
        }
    }

#endif
}