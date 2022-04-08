using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationReached : GameManager
{
    
    //détermine si un Ennemi entre en contact avec lui
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        { 
            other.GetComponent<Ennemies>().isRemovable = true;
            Destroy(other.gameObject);
            pvJoueur--;
            Debug.Log(pvJoueur);
        }
    }



}
