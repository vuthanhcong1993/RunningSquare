using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//concretecommand
public class PlayerUltimate : ICommand
{
    public void Execute(PlayerCommand playerCommand)
    {
        playerCommand.ExecuteCommand();
    }
}