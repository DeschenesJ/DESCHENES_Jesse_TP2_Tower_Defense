using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationReached : MonoBehaviour
{

    //détermine si un Ennemi entre en contact avec lui
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ennemi"))
            other.GetComponent<Ennemies>().isRemovable = true;
        Debug.Log("Je vois un ennemi");
    }





}
