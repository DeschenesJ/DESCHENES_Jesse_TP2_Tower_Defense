using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Warrok : Ennemies
{
    bool isDuplicate;

    protected override void Setup()
    {
        pvEnnemi = 8;
        if (isDuplicate == true)
        {
            // valeur qui sert pou diviser les pv du Warrok en deux pour ses doubles
            float pvEnnemiFlt = pvEnnemi;
            pvEnnemi = Mathf.RoundToInt(pvEnnemiFlt * 0.5f);
            ennemiGold = 75;
        }
       // Valeur de test
        // ennemiGold = 150;
    }
    
    //void 

}
