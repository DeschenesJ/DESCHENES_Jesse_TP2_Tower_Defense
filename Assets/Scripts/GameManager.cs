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
    // Pv du joueur
    int pvJoueur;
    public int PvJoueur { get { return pvJoueur; } set { pvJoueur = value; } }
    // Valeur pour lorsque la partie est fini
    bool gameOver ;
    public bool GameOver { get { return gameOver; } set { gameOver = value; } }
    // Valeurs de test pour le while
    int x;
    //------------------------------

    // va être modifié dans une coroutine qui va déterminer le nombre de round
    float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        x = 0;
        pvJoueur = 1;
        gameOver = false;
        // Commence la coroutine pour faire apparaitre la vague
        StartCoroutine(Spawner());

        
    }

    // Update is called once per frame
    void Update()
    {
        //  Va stopper la coroutine une fois les pv du joueur à 0
        if (pvJoueur == 0)
            theGameisOver();
    }

    // Methode qui va faire apparaitre les ennemis
    IEnumerator Spawner()
    {
        while (true)
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

    }
    void EnnemiSpawn(GameObject ennemiType)
    {
        // fait apparaitre un préfab de l'ennemi désiré
        GameObject objEnnemi = Instantiate(ennemiType, spawnpoint.position, Quaternion.Euler(180f, 0f, 0f)).gameObject;
        // détermine la cible de l'ennemi
        Ennemies ennemies = objEnnemi.GetComponent<Ennemies>();
        ennemies.SetTarget(endPoint);
    }

    void theGameisOver()
    {
        StopAllCoroutines();
        gameOver = true;


        
    
    
    }

}
