using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralLayer : MonoBehaviour
{
    #region Variables
    public static LayerMask Target = LayerMask.GetMask("Target");
    public static LayerMask Player = LayerMask.GetMask("Player");
    public static LayerMask CheckMagnet = LayerMask.GetMask("CheckMagnet");
    #endregion

   
}