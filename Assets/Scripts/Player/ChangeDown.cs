using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ChangeDown : IPlayerCommand
{
    public override void Execute(PlayerController playerController)
    {
        Move(playerController, -1);
    }
}
