using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public float speed = 6.0F;
    private Vector3 moveDirection = Vector3.zero;

    void Update () {
        CharacterController controller = GetComponent<CharacterController> ();
        moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
        moveDirection = transform.TransformDirection (moveDirection);
        moveDirection *= speed;
        controller.Move (moveDirection * Time.deltaTime);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }

}