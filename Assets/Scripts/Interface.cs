using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Button ButtonPlay;
    public Button ButtonPause;
    public Button ButtonTowerGun;
    public Button ButtonCannonGun;
    public Button ButtonSlowerGun;

    public Text txtTimer;
    float timer;
    public Text txtvague;
    public Text txtMoney;
    public Text txtLife;
    public Text txtennemieskilled;
    GameManager manager;
    GameObject SelectedTurret;
    BuildManager BuildManager;
    
    // Start is called before the first frame update
    void Start()
    {
        //SelectedTurret = BuildManager.TurretBuilder;
        ButtonPlay.onClick.AddListener(ButtonPlayClicked);
        ButtonPause.onClick.AddListener(ButtonPauseClicked);
        ButtonPause.gameObject.SetActive(false);

        manager = FindObjectOfType<GameManager>();
       // BuildManager = FindObjectOfType<BuildManager>();

    }
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        txtTimer.text = timer.ToString();
        txtTimer.text = string.Format("{0:0}:{1:00}",
                   Mathf.Floor(timer / 60),   // Minutes
                   Mathf.Floor(timer) % 60);  // seconds
        txtLife.text = manager.PvJoueur.ToString();
        txtennemieskilled.text = manager.KillCount.ToString();
        txtMoney.text = manager.GoldJoueur.ToString();
        txtvague.text = manager.IVague.ToString();

    }
    void ButtonPlayClicked()
    {
        
        ButtonPlay.gameObject.SetActive(false);
        ButtonPause.gameObject.SetActive(true);
        
    }
    void ButtonPauseClicked()
    {
        ButtonPlay.gameObject.SetActive(true);
        ButtonPause.gameObject.SetActive(false);
    }
}
