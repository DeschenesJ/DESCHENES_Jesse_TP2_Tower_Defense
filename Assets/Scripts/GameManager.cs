using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform spawnpoint;
    public Transform endPoint;
    // Squeulette
    public GameObject ennemiS;
    // Nightshade
    public GameObject ennemiN;
    // Warrok
    public GameObject ennemiW;

    int pvJoueur;

    public int PvJoueur { set { value = pvJoueur = 6; } }

    // Valeurs de test pour le while
    int x;
    bool listFull;
    //------------------------------

    // va être modifié dans une coroutine qui va déterminer le nombre de round
    float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        x = 0;
        listFull = false;
        // Commence la coroutine pour faire apparaitre la vague
        StartCoroutine(Spawner());

        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    // Methode qui va faire apparaitre les ennemis
    IEnumerator Spawner()
    {
        while (x < 2)
        {
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
            x++;
        }
        listFull = true;

    }
    void EnnemiSpawn(GameObject ennemiType)
    {
        // fait apparaitre un préfab de l'ennemi désiré
        GameObject objEnnemi = Instantiate(ennemiType, spawnpoint.position, Quaternion.Euler(180f, 0f, 0f)).gameObject;
        // détermine la cible de l'ennemi
        Ennemies ennemies = objEnnemi.GetComponent<Ennemies>();
        ennemies.SetTarget(endPoint);
    }

}
