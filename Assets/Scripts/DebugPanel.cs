using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : BetterMonoBehaviour {

    private GameObject[] portals;
    private PlayerController playerController;
    private PlayerInput playerInput;
    private CanvasGroup group;

    void Start () {
        portals = GameObject.FindGameObjectsWithTag("Portal").OrderBy(portal => portal.name).ToArray();
        playerController = FindObjectOfType<PlayerController>();
        playerInput = GetPlayerInput();

        group = GetComponentOrThrow<CanvasGroup>();
        group.alpha = 0.0f;
        group.interactable = false;

        Dropdown dropdown = GameObject.Find("Beam Player Dropdown").GetComponent<Dropdown>();
        dropdown.AddOptions(portals.Select(o => new Dropdown.OptionData(o.name)).ToList());
        dropdown.value = 0;
        dropdown.onValueChanged.AddListener(position => {
            playerController.gameObject.transform.position = portals[position].transform.position + new Vector3(0.0f, 2.0f, 0.0f);
        });

        Toggle deathOnFall = GameObject.Find("Death On Fall Toggle").GetComponent<Toggle>();
        deathOnFall.isOn = playerController.DeathOnFall;
        deathOnFall.onValueChanged.AddListener(isOn => {
            playerController.DeathOnFall = isOn;
        });
    }
    
    void Update () {
        if (playerInput.ToggleDebugPanel) {
            group.interactable = !group.interactable;
            group.alpha = group.interactable ? 1.0f : 0.0f;
        }
    }
}
