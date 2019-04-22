using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//concretecommand
public class PlayerImmortal : ICommand
{
    public void Execute(PlayerCommand playerCommand)
    {
        playerCommand.ExecuteCommand();
    }
}