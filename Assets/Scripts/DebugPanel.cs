using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour {

	private GameObject[] portals;
	private PlayerController playerController;

	void Start () {
		portals = GameObject.FindGameObjectsWithTag("Portal").OrderBy(portal => portal.name).ToArray();
		playerController = FindObjectOfType<PlayerController>();

		Dropdown dropdown = GameObject.Find("Beam Player Dropdown").GetComponent<Dropdown>();
		dropdown.AddOptions(portals.Select(o => new Dropdown.OptionData(o.name)).ToList());
		dropdown.value = 0;
		dropdown.onValueChanged.AddListener(position => {
            playerController.gameObject.transform.position = portals[position].transform.position + new Vector3(0.0f, 2.0f, 0.0f);
		});

		gameObject.SetActive(false);
	}
	
	void Update () {
		
	}
}
