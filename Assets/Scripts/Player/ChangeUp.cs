using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUp : IPlayerCommand
{
    public override void Execute(PlayerController playerController)
    {
        Move(playerController,1);
    }
}


