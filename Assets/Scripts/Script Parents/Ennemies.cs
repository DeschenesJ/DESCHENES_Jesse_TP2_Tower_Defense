using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemies : MonoBehaviour, IDamageable
{
    // valeur de référence pour les rigid bodies
    protected Rigidbody[] rbEnnemi;
    // valeur de référence pour l'animator
    protected Animator animator;
    //valeur pour la vie de l'ennemi
    protected int pvEnnemi = 4;
    // Le navMesh pour l'ennemi
    NavMeshAgent agent;
    // Variable qui va dire au Gamemanager que l'ennemi est mort
    protected bool Mort = false;
    // Variable qui dit à l'ennemi est touché Je vais peut-être devoir le changer d'endroit
    protected bool degats = false;
    // Valeurs de test pour la position
    Vector3 vecDestination;
    // ------------------

    // Start is called before the first frame update
    void Start()
    {
        // va chercher les références des rigid bodies de l'ennemi
        rbEnnemi = GetComponentsInChildren<Rigidbody>();
        // va chercher la référence de l'animator de l'ennemi
        animator = GetComponent<Animator>();
        // Désactive le ragdoll
        ToggleRagdoll(false);
        vecDestination = new Vector3(15.51f, 0f, -52f);
        // va chercher le navmesh de l'ennemi
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        //Set la destination de la target
        agent.SetDestination(vecDestination);


        // Est vide pour l'instant

    }


    public void TakeDamage(bool Degats)
    {
        Degats = degats;
        // Va déterminer si l'ennemi se prend des dégâts ou s'il meurt
        if (pvEnnemi > 0)
        {

            // lorsque l'ennemi est touché, il perd un pv
            pvEnnemi--;
            // Audio cri ennemi

        }
        else
            // Lorsque l'ennemie n'a plus de PV, il meurt
            die();
    }
    // Ce qui ce produit lorsque l'ennemi meurt
    void die()
    {
        // Active le Ragdoll
        ToggleRagdoll(true);

        // Active l'audio


        // Active Particules pour mort

    }



    protected void ToggleRagdoll(bool value)
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
