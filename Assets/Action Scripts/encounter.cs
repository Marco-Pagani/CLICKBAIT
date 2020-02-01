using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class encounter : MonoBehaviour {
    public string characterName = "Generic";
    public int id = 0;
    public EncounterManager manager;
    public GameObject dlWindow;
    bool is_near = false;
    private bool action_pressed = false;

    void FixedUpdate () {
        if (Input.GetAxis ("Jump") != 0 && is_near) {
            if (!action_pressed) {
                action_pressed = true;
                Interact ();
                
                if (dlWindow.activeInHierarchy) {
                    dlWindow.SetActive (false);
                } else {
                    dlWindow.SetActive (true);
                }
            }
        } else {
            action_pressed = false;
        }

    }

    private void OnTriggerEnter (Collider other) {
        is_near = true;
    }

    private void OnTriggerExit (Collider other) {
        is_near = false;
    }

    private void Interact () {
        if (is_near && gameObject.activeSelf) {
            Debug.Log (id);
            var e = manager.get_encounter (characterName);
            Debug.Log (e.prompt);
            manager.scramble_meeples (gameObject);
            is_near = false;
        }
    }
}