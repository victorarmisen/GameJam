using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigidRef;
    public Camera camRef;
    public float speed = 5;

    void Start()
    {
        rigidRef = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Vector3 mouseDir = camRef.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10)) - camRef.ScreenToWorldPoint(Input.mousePosition);
            if (Physics.Raycast(camRef.transform.position, mouseDir, out hit))
            {
                Debug.DrawLine(transform.position, hit.point, Color.blue, 10);
                rigidRef.AddForce((hit.point - transform.position).normalized * speed * 300);
            }
        }
    }
}
