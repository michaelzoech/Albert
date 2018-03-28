using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour {

    public enum Direction {
        In,
        Out
    }

    private float startTime;
    private float duration;
    private Direction direction;

    void OnGUI() {
        float timeDifference = Time.time - startTime;

        if (timeDifference > duration * 2.0f) {
            return;
        }

        float alpha = 0.0f;
        switch (direction) {
            case Direction.In:
                alpha = Mathf.SmoothStep(1.0f, 0.0f, timeDifference / duration);
                break;
            case Direction.Out:
                alpha = Mathf.SmoothStep(0.0f, 1.0f, timeDifference / duration);
                break;
        }

        Texture2D myTex;
        myTex = new Texture2D (1, 1);
        myTex.SetPixel (0, 0, new Color(0.0f, 0.0f, 0.0f, alpha));
        myTex.Apply ();

        GUI.DrawTexture(new Rect(0.0f, 0.0f, Screen.width, Screen.height), myTex);
    }

    public void StartFade(Direction direction, float duration = 1.0f) {
        Conditions.Assert(duration > 0.0f, "Duration has to be greater than 0");
        this.startTime = Time.time;
        this.duration = duration;
        this.direction = direction;
    }
}
