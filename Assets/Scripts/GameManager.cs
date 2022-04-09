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
    // Valeur qui permet de supprimer les prefab ennemis
    bool gameOver ;
    public bool GameOver { get { return gameOver; } set { gameOver = value; } }
    // Valeur utilisé pour déterminer si tous les ennemis sont morts
    int deadAll;
    //valeur de l'ennemi lorsqu'il est mort et va être vérifiée avec isDeadAll pour les comparer
    int killed;
    public int Killed { get { return killed ; } set { killed = value ; } }
    // Valeurs de référence pour faire apparaître les ennemis ---
    // Squelette
    int iEnnemiS;
    // NightShade
    int iEnnemiN;
    // Warrok
    int iEnnemiW;
    // Variable pour indiquer le nombre de la vague
    int iVague;
    //-----------------------------------------------------------

    // valeur fixe pour le temps entre les vaagues
    float spawnVagueInterval = 20f;
    // valeur fixe pour le délay entre chaque spawn d'ennemi
    float spawnDelay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        pvJoueur = 6;
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
        if (killed == deadAll && deadAll != 0)
            theGameisOver();
    }

    // Methode qui va faire apparaitre les ennemis
    IEnumerator Spawner()
    {
        //la valeiur de la vague
        iVague++;
        // le nombre de squelette par vague
        iEnnemiS = 1 + iVague;
        // le nombre de Nightshade par vague
        iEnnemiN = iVague - 1;
        // le nommbre de Warrok par vague--
        iEnnemiW = iVague - 2;
        if (iEnnemiW <= 0)
            iEnnemiW = 0;
        //---------------------------------
        // La quantité d'ennemi dans la variable qui détermine si tous les ennemis sont mort
        deadAll = iEnnemiS + iEnnemiN + iEnnemiW;
        //Variable qui sert à arrêter la boucle while
        int iW = 0;
        //le délais entre chaque vague
        yield return new WaitForSeconds(spawnVagueInterval);
        // Boucle qui va mettre les ennemis dans la vague
        while (iW < iEnnemiS + iEnnemiN + iEnnemiW)
        {
            // Spawn des ennemis (je vais devoir faire une boucle selon la vague)            
            for (int iSpawn = 0; iSpawn < iEnnemiS; iSpawn++, iW++)
            {
                EnnemiSpawn(ennemiS);
                yield return new WaitForSeconds(spawnDelay);
            }
            //----------------
            for (int iSpawn = 0; iSpawn < iEnnemiN; iSpawn++, iW++)
            {
                EnnemiSpawn(ennemiN);
                yield return new WaitForSeconds(spawnDelay);
            }
            //----------------
            for (int iSpawn = 0; iSpawn < iEnnemiW; iSpawn++, iW++)
            {
                EnnemiSpawn(ennemiW);
                yield return new WaitForSeconds(spawnDelay);
            }
            
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
        // La partie est terminé
        if (pvJoueur == 0)
            gameOver = true;
        else // ce déclenche seulement si le joueur est encore en vie lorsque la méthode est appelée pour
             // commencer une nouvelle vague
        {
            deadAll = 0;
            killed = 0;
            StartCoroutine(Spawner());
        }
    }
}
