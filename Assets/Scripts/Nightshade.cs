using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nightshade : Ennemies
{
    int pvEnnemi = 2;

    void Update()
    {

        //Set la destination de la target
        agent.SetDestination(vecDestination);
        




    }

    // Lorsque la nightshade entre dans un box collider des shortcut
    private void OnTriggerEnter(Collider other)
    {

        // Va activer l'animation de float de la nightshade
        if (other.CompareTag("Shortcut"))
            animator.SetBool("IsFloating", true);
    }
    // Lorsque la Nightshade sort d'un box collider des shortcut
    private void OnTriggerExit(Collider other)
    { 
        // va activer l'animation de marche de la nightshade
        if (other.CompareTag("Shortcut"))
            animator.SetBool("IsFloating", false);
    }


}
