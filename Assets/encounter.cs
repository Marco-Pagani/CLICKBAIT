using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encounter : MonoBehaviour {

    bool is_near = false;
    private bool action_pressed = false;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetAxis ("Jump") != 0) {
            if (!action_pressed) {
                action_pressed = true;
                Interact ();
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
        if (is_near)
            Debug.Log ("Interact");
    }
}