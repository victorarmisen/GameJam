using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambio_Efectos : MonoBehaviour
{

    //Cambio de estado segun colision de proyectil. 

    public MonoBehaviour[] scripts;

    private void Start()
    {
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }

    void Basic()
    {
        //Volvemos a activar las mecanicas basicas del jugador que nunca 
        //se desactivan.
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        this.GetComponent<Cambio_Efectos>().enabled = true;
    }

    void Desactivate_All_Scripts()
    {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Tipos de scripts aqui.
        if (collision.gameObject.tag == "Slime")

        {   //Desactivamos los demas.
            Desactivate_All_Scripts();
            //Activamos script slime.  
            gameObject.GetComponent<Slime>().enabled = true;
            Basic();
        }

        //Tipos de scripts aqui.
        if (collision.gameObject.tag == "Chicle")

        {   //Desactivamos los demas.
            Desactivate_All_Scripts();
            //Activamos script slime.  
            //gameObject.GetComponent<Slime>.enabled = true;
            gameObject.GetComponent<Chicle>().enabled = true;
            Basic();
        }




    }


}
