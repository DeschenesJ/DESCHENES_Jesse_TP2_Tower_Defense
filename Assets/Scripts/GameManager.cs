using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform spawnpoint;
    public Transform endPoint;
    public GameObject ennemiS;
    public GameObject ennemiN;
    public GameObject ennemiW;

    // va être modifié dans une coroutine qui va déterminer le nombre de round
    float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        // Commence la coroutine pour faire apparaitre la vague
        StartCoroutine(Spawner());

        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(Spawner());


    }

    // Methode qui va faire apparaitre les ennemis
    IEnumerator Spawner()
    {
        while (true)
        {
            // Déterminer la position des ennemies
           // Vector3 location = spawnpoint.position;

            

            // Un indicateur circulaire apparaitra à cette position pour que le joueur puisse s'en éloigner
            //Vector3 indicatorLocation = location;
            //indicatorLocation.y = 0.03f;
           // spawnpoint.position = indicatorLocation;

            // Attendre un léger interval avant de le faire spawn
            yield return new WaitForSeconds(spawnInterval);
            // Spawn des ennemis (je vais devoir faire une boucle selon la vague)            
            EnnemiSpawn(ennemiS);
            yield return new WaitForSeconds(spawnInterval);
            EnnemiSpawn(ennemiN);
            yield return new WaitForSeconds(spawnInterval);
            EnnemiSpawn(ennemiW);

            spawnInterval -= 0.25f;

            if (spawnInterval < 1f)
                spawnInterval = 1f;
        }

    }
    void EnnemiSpawn(GameObject ennemiType)
    {
        GameObject objEnnemi = Instantiate(ennemiType, spawnpoint.position, Quaternion.Euler(180f, 0f, 0f)).gameObject;
        objEnnemi.GetComponent<Ennemies>().SetTarget(endPoint);
    }

}
