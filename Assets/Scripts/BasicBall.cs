using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBall : Ball
{
    public static List<BasicBall> balls = new List<BasicBall>();

    public void Start()
    {
        balls.Add(this);
    }
}
