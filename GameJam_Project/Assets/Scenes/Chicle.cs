using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicle : MonoBehaviour
{
    //Dos estados. 
    public bool ModoChicle = false;
    public bool Impulso = false;
    public bool OnPared = false;
    public Rigidbody body;


    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && ModoChicle)
        {
            //Player quieto. 
            body.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            Impulso = true;
        }
        
        if(Input.GetKeyDown(KeyCode.F) && Impulso)
        {
            body.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            body.AddForce(gameObject.transform.forward * 10.0f, ForceMode.Impulse);
            Impulso = false;
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pared")
            ModoChicle = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Pared")
            ModoChicle = false;
    }

}
