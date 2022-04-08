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
    protected int pvEnnemi;
    // Le navMesh pour l'ennemi
    protected NavMeshAgent agent;
    // Variable qui dit à l'ennemi est touché Je vais peut-être devoir le changer d'endroit
    protected bool degats = false;
    //-----------------------------------
    // Variable qui va servir a dire au gamemanager que le préfab de l'ennemi peut être détruit
    public bool isRemovable;
    // Variable qui va indiquée au gamemanager que l'ennemi est arriver à destination
    public bool reachTarget;
    //-----------------------------------
    // Valeur de destination pour les ennemies qui va être caller par le gamemanager
    protected Transform destination;

    // Valeur qui va permettre de détecter l'ennemi
    protected Collider colliderEnnemi;


    // Start is called before the first frame update
    void Start()
    {
        // va chercher les références des rigid bodies de l'ennemi
        rbEnnemi = GetComponentsInChildren<Rigidbody>();
        // va chercher la référence de l'animator de l'ennemi
        animator = GetComponent<Animator>();
        // Désactive le ragdoll
        ToggleRagdoll(false);
        // va chercher le collider de l'ennemi
        colliderEnnemi = GetComponent<Collider>();
        isRemovable = false;
        Setup();


    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // méthode pour la destination des ennemies qui est caller
    public void SetTarget(Transform endDestination)
    {
        
        // va chercher le navmesh de l'ennemi
        agent = GetComponent<NavMeshAgent>();
        
        destination = endDestination;

        agent.SetDestination(destination.position);
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
            // Lorsque l'ennemie n'a plus de PV, il meurt ou lorsqu'il est arrivé à destination, il disparait 
            endOrIsDead();
    }
    // Ce qui ce produit lorsque l'ennemi meurt
    public void endOrIsDead()
    {
        // Active le Ragdoll si l'ennmei n'a plus de pv
        if (pvEnnemi <= 0)
        {
            // Active l'audio de mort

            // Méthode qui va servie pour le ragdoll de l'ennemi
            ToggleRagdoll(true);
            // Active Particules pour mort

            isRemovable = true;

        }
        else
            reachTarget = true;
            isRemovable = true;
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

    protected virtual void Setup()
    {
        // Détermine les pv de l'ennemi
        pvEnnemi = 4;
        // Détermine la valeur de l'ennemi


    }



}
