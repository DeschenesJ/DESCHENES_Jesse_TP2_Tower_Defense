using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private GameObject TurretToBuild;
    public GameObject TurretBuilder;
    public GameObject GunTurret;
    public GameObject CannonTurret;
    public GameObject FrostTurret;
    private void Awake()
    {
        instance = this;
    }
   
   
    
    public GameObject GetTurretToBuild()
    {
        return TurretToBuild;
    }
   public void SetTurretToBuild(GameObject turret)
    {
        TurretToBuild = turret;
    }
}
