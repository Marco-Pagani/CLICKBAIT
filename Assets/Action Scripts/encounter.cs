using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class encounter : MonoBehaviour {
    public string characterName = "Tana";
    public EncounterManager manager;
    public GameObject dlWindow;
    bool is_near = false;
    private bool action_pressed = false;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
       // if (Input.GetAxis ("Jump") != 0) {
        if (Input.GetKeyDown(KeyCode.Space) && is_near) {
            if (!action_pressed) {
                action_pressed = true;
                Interact ();
            }
            if(dlWindow.activeInHierarchy){
                dlWindow.SetActive(false);
            }
            else{
                dlWindow.SetActive(true);
            }
        } else {
            action_pressed = false;
        }
    }

    private void OnTriggerEnter (Collider other) {
        //Debug.Log ("Enter");
        is_near = true;
    }

    private void OnTriggerExit (Collider other) {
        is_near = false;
    }

    private void Interact () {
        if (is_near){
            var e = manager.get_encounter (characterName);
            //Debug.Log (e.prompt);
        }
    }
}