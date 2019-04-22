using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRole : IPlayerCommand {
    [SerializeField] private MapBuilder createMap = null;

    public override void Execute(PlayerController playerController)
    {
        ChangeRole(playerController, createMap);
    }

}
