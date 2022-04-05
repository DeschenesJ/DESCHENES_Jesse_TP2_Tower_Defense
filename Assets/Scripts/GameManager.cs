using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject spawnpoint;
    public GameObject ennemiS;
    public GameObject ennemiN;
    public GameObject ennemiW;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Spawner());
    }

    // Methode qui va faire apparaitre les ennemis
    IEnumerator Spawner()
    {
        return null;
    }

}
