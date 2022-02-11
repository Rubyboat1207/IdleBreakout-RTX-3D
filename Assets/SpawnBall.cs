using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    Ball Balltype;
    void OnMouseDown()
    {
        var ball = Instantiate(Balltype);
        ball.transform.position = new Vector3(0, 0, 0);
    }
}
