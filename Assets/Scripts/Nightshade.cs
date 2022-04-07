using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nightshade : Ennemies
{
    


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

    protected override void Setup()
    {
        base.pvEnnemi = 2;
    }


}
