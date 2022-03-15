using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundHandler
{
    public static int RoundNumber = 1;
    public static void NextRound()
    {
        RoundNumber++;
        GameObject.Find("Inverted Cube").GetComponent<BrickLoader>().LoadLevel();
    }
}
