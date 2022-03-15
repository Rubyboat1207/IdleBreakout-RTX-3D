using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBall : Ball
{
    public override void OnWallCollide()
    {
        Debug.Log("Redirect");
        Brick closest = GetClosestBrick(transform.position);
        vector = (closest.transform.position - transform.position).normalized;
    }
}
