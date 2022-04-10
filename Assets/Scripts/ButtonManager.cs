using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    BuildManager buildManager;
    GameManager manager;
    void Start()
    {

        // Construit le manager pour la construction
        buildManager = BuildManager.instance;
        manager = GetComponent<GameManager>();

    }
    public void GunTurretButton()
    {
       // if (manager.GoldJoueur >= 50)
       // {
            buildManager.SetTurretToBuild(buildManager.GunTurret);
          //  manager.GoldJoueur -= 50;
       // }
    }
    public void FrostTurretButton()
    {
       // if (manager.GoldJoueur >= 300)
        //{
            buildManager.SetTurretToBuild(buildManager.FrostTurret);
           // manager.GoldJoueur -= 300;
       // }
    }

    public void CannonTurretButton()
    {
       // if (manager.GoldJoueur >= 500)
       // { 
            buildManager.SetTurretToBuild(buildManager.CannonTurret);
         //   manager.GoldJoueur -= 500;
       // }

    }


}
