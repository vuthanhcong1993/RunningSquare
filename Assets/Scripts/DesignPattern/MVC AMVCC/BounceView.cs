using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceView : BounceElement
{
    // Reference to the ball
    public BounceView ball;
    void OnCollisionEnter() { /*app.controller.OnBallGroundHit();*/ }
}
