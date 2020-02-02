using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class encounter : MonoBehaviour {
    public string characterName = "Generic";
    public EncounterManager manager;
    public GameObject dlWindow;
    public Animator anim;
    bool is_near = false;
    private bool action_pressed = false;

    void FixedUpdate () {
        if (Input.GetAxis ("Jump") != 0 && is_near) {
            if (!action_pressed) {
                action_pressed = true;
                Interact ();

            }
        } else {
            action_pressed = false;
        }

    }

    private void OnTriggerEnter (Collider other) {
        //Debug.Log ("Near");
        is_near = true;
    }

    private void OnTriggerExit (Collider other) {
        is_near = false;
    }

    private void Interact () {
        if (is_near && gameObject.activeSelf) {
            var e = manager.get_encounter (characterName);
            if (dlWindow.activeInHierarchy) {
                dlWindow.SetActive (false);
            } else {
                dlWindow.SetActive (true);
                dlWindow.GetComponent<DialogueScript> ().displayEncounter (e);
                //anim = GetComponent<Animator>();
                //anim.Play("zoom_i01");
                //Button[] buttons = GetComponentsInChildren<Button>
                //GameObject currentButton = null;
                /*
                for (int i = 0; i < 3; i++){
                    //button = dlWindow.
                    currentButton = gameObject.transform.Find("button" + i);
                    currentButton.GetComponent<Animator>().Play();
                }
                */
                
            }
            //Debug.Log (e.prompt);

            is_near = false;
        } else {
            //Debug.Log ("No Encounter");
        }

    }
}