using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject playerRef;
    private Vector3 directionVector;
    private float force = 1.0f;
    void Start()
    {
        Invoke("Destroy", 5.0f);
        playerRef = GameObject.FindGameObjectWithTag("Player");
        directionVector = playerRef.transform.position - transform.position;
        gameObject.GetComponent<Rigidbody>().velocity = directionVector;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void Destroy()
    {
        Destroy(this.gameObject);
        Destroy(this);
    }
}
