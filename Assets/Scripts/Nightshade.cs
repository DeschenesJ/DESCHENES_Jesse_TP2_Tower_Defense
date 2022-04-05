using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nightshade : Ennemies
{
    int pvEnnemi = 2;
    



    void Update()
    {

        if (animator.isFloating)
        //Set la destination de la target
        agent.SetDestination(vecDestination);
        
    }



}
