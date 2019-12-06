using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Vector3 movement, lastMovement;
    public float speed = 5;
    public float rotationSpeed = 5;
    private bool onGround = true;
    private float mouseRotation;

    private Rigidbody rigidRef;
    public Camera camRef;

    // Use this for initialization
    void Start () {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        rigidRef = GetComponent<Rigidbody>();
        lastMovement = movement = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {

        movement.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        movement.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        mouseRotation = Input.GetAxis("Mouse X") * rotationSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && onGround) rigidRef.AddForce(0, 500, 0);

        if (movement.magnitude > 0 && onGround && !GetComponent<Chicle>().Impulso) {

            transform.Translate(movement);
            lastMovement = movement;
            movement = Vector3.zero;

        }

        if (!onGround) {

            transform.Translate(movement);

        }

        transform.Rotate(0, mouseRotation, 0);

    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Ground") onGround = true;
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "Ground") onGround = false;
    }

}
