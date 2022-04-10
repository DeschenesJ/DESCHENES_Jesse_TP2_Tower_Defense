using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    public Color HoverColor;
    private Renderer rend;
    private Color BaseColor;
    private GameObject turret;
    BuildManager buildManager;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Renderer>();
        BaseColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    private void OnMouseDown()
    {
       if (Input.GetButtonDown("Fire1"))
        {
            if (buildManager.GetTurretToBuild() == null)
            {
                
                return;
            }

            if (turret !=null)
            {
                Destroy(turret);
            return;
            }
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
        }
       


    }

    void OnMouseEnter()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
        rend.material.color = HoverColor;
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        rend.material.color = BaseColor;
    }
}
