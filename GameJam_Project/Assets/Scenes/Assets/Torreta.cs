using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public string element;
    public GameObject playerRef;
    public GameObject bullet;
    public GameObject bone;
    public Transform cannon;
    public ParticleSystem slimeShotParticles;
    public ParticleSystem iceShotParticles;
    public ParticleSystem airShotParticles;
    public ParticleSystem chicleShotParticles;
    public Material slimeMaterial;
    public Material iceMaterial;
    public Material chicleMaterial;
    public Material airMaterial;

    public float fireRate;
    private float resetFireRate;
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        resetFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {

        bone.transform.rotation = Quaternion.LookRotation(playerRef.transform.position);
        bone.transform.rotation = bone.transform.rotation * Quaternion.Euler(180,90,0);

        if (fireRate <=0.0f)
        {
            if(element == "Slime")
            {
                GameObject slime_projectil = Instantiate(bullet, cannon.position, cannon.rotation) as GameObject;
                slime_projectil.GetComponent<Renderer>().material = slimeMaterial;
                slime_projectil.gameObject.tag = element;
                Instantiate(slimeShotParticles, cannon.position, bone.transform.rotation * Quaternion.Euler(0, -90, 0));
            }
                
            if (element == "Ice")
            {
                Instantiate(bullet, cannon.position, cannon.rotation).GetComponent<Renderer>().material = iceMaterial;
                Instantiate(iceShotParticles, cannon.position, bone.transform.rotation * Quaternion.Euler(0, -90, 0));
            }
               
            if (element == "Air")
            {
                Instantiate(bullet, cannon.position, cannon.rotation).GetComponent<Renderer>().material = airMaterial;
                Instantiate(airShotParticles, cannon.position, bone.transform.rotation * Quaternion.Euler(0, -90, 0));
            }
              
            if (element == "Chicle")
            {
                GameObject slime_projectil = Instantiate(bullet, cannon.position, cannon.rotation) as GameObject;
                slime_projectil.GetComponent<Renderer>().material = slimeMaterial;
                slime_projectil.gameObject.tag = element;
                Instantiate(slimeShotParticles, cannon.position, bone.transform.rotation * Quaternion.Euler(0, -90, 0));
            }   
           
            fireRate = resetFireRate;
        }
        else
        {
            fireRate -= Time.deltaTime;
        }
    }
}
