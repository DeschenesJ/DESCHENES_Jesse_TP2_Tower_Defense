using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : Turret
{

    protected override void Setup()
    {
        base.FireCountdown = 1;
    }


}
