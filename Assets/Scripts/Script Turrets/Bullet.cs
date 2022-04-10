using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    
    // Start is called before the first frame update
    public void ReachEnnemies(Transform _target)
    {
        target = _target;
    }
    

    // Update is called once per frame
    void Update()
    {
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
   void HitTarget()
    {
        
        Destroy(gameObject);
    }
  }
