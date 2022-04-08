using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // le point d'apparition des ennemis
    public Transform spawnpoint;
    // le point de la destination finale des ennemis
    public Transform endPoint;
    // Squelette
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
    // Valeurs de référence pour faire apparaître les ennemis
    // Squelette
    int iEnnemiS;
    // NightShade
    int iEnnemiN;
    // Warrok
    int iEnnemiW;
    //Valeur pour faire apparaitre les ennemis
    int iSpawn;
    // Variable pour indiquer le nombre de la vague
    int iVague;
    //------------------------------

    // va être modifié dans une coroutine qui va déterminer le nombre de round
    float spawnInterval = 5f;

    // Start is called before the first frame update
    void Start()
    {
        iSpawn = 0;

        instance = this;
        pvJoueur = 1;
        // le je n'est pas terminé au commencement de la partie alors la variable est à false
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
        //iVague va être manuellement modifiée pour les besoins de test
        iVague = 1;
        iEnnemiS = 1 + iVague;
        iEnnemiN = 1 + iVague - 1;
        iEnnemiW = iVague - 1;
        int iW = 0;

        while (iW <= iEnnemiS + iEnnemiN + iEnnemiW)
        {
            // Attendre un léger interval avant de le faire spawn
            yield return new WaitForSeconds(spawnInterval);
            // Spawn des ennemis (je vais devoir faire une boucle selon la vague)            
            while (iSpawn <= iEnnemiS)
            {
                EnnemiSpawn(ennemiS);
                // variable à ajouter
            }
            yield return new WaitForSeconds(spawnInterval);
            EnnemiSpawn(ennemiN);
            yield return new WaitForSeconds(spawnInterval);
            EnnemiSpawn(ennemiW);

            spawnInterval -= 0.25f;

            if (spawnInterval < 1f)
                spawnInterval = 1f;
            
        }

    }
    // Méthode pour faire apparaître les types d'ennemis
    void EnnemiSpawn(GameObject ennemiType)
    {
        // fait apparaitre un préfab de l'ennemi désiré
        GameObject objEnnemi = Instantiate(ennemiType, spawnpoint.position, Quaternion.Euler(180f, 0f, 0f)).gameObject;
        // détermine la cible de l'ennemi
        Ennemies ennemies = objEnnemi.GetComponent<Ennemies>();
        ennemies.SetTarget(endPoint);
    }

    // va déterminer si la partie est terminée
    void theGameisOver()
    {
        StopAllCoroutines();
        gameOver = true;


        
    
    
    }

}
