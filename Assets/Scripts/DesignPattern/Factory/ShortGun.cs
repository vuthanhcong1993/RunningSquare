using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortGun : GunBase {

    private void Start()
    {
        bullet = 1;
        damage = 2;
        isKnife = true;
    }

    public override void Title()
    {
        print("Type: ShortGun");
    }
}
