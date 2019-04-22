using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : GunBase {

    private void Start()
    {
        bullet = 1;
        damage = 2;
        isSilence = true;
    }

    public override void Title()
    {
        print("Type: Pistol");
    }
}
