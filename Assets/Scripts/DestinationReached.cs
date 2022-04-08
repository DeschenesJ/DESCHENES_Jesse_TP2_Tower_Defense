using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationReached : MonoBehaviour
{
    
    //détermine si un Ennemi entre en contact avec lui
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
        { 
            other.GetComponent<Ennemies>().isRemovable = true;
            Destroy(other.gameObject);
            GameManager manager = FindObjectOfType<GameManager>();
            manager.PvJoueur--;
            // pvJoueur--;
            // Debug.Log(pvJoueur);
            Debug.Log(manager.PvJoueur);
        }
    }



}
