using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    
    //Suit l'ennemi
    public void ReachEnnemies(Transform _target)
    {
        target = _target;
    }
    

    // Update is called once per frame
    void Update()
    {
        // La balle ce détruit s'il n'y a pas d'ennemis
        if (transform == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 Deplacement = target.position - transform.position;
        float distence = speed * Time.deltaTime;
        if (Deplacement.magnitude <= distence)
        {
            HitTarget();
            return;
        }
        transform.Translate(Deplacement.normalized * distence, Space.World);
    }
    // La balle se détruit
   void HitTarget()
   {
        
        Destroy(gameObject);
   }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ennemi"))
        {
            Ennemies otEnnemi = other.GetComponent<Ennemies>();
            // other.GetComponent<Ennemies>();
            // variable qui va chercher le GameManager
            otEnnemi.Degats = true;
        }

    }

}
