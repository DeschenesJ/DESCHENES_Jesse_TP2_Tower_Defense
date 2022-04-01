using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ennemies : MonoBehaviour, IDamageable
{
    // valeur de référence pour les rigid bodies
    Rigidbody[] rbEnnemi;
    // valeur de référence pour l'animator
    Animator animator;


    // Valeurs complètement inutiles, ne me sert que pour planifier comment je vais faire mon script
    float x;
    float y;
    float z;
    // ------------------

    // Start is called before the first frame update
    void Start()
    {

        // va chercher les références des rigid bodies de l'ennemi
        rbEnnemi = GetComponentsInChildren<Rigidbody>();
        // va chercher la référence de l'animator de l'ennemi
        animator = GetComponent<Animator>();

        // Désactive le ragdoll
        ToggleRagodll(false);

    }

    // Update is called once per frame
    void Update()
    {

        // Est vide pour l'instant

    }


    public void TakeDamage()
    {
        // Va déterminer si l'ennemi se prend des dégâts ou s'il meurt
        if ( x > 1)
        {

            // lorsque l'ennemi est touché, il perd un pv

            
        }
        else
            // Lorsque l'ennemie n'a plus de PV, il meurt
            die();
    }
    // Ce qui ce produit lorsque l'ennemi meurt
    void die()
    {
        // Active le Ragdoll
        ToggleRagodll(true);

        // Active l'audio


        // Active Particules pour mort

    }



    private void ToggleRagodll(bool value)
    {
        //Activer/desactiver les rigidbodies
        foreach (var r in rbEnnemi)
        {
            r.isKinematic = !value;
        }

        //Activer/desactiver l'Animator
        animator.enabled = !value;
    }
}
