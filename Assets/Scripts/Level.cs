using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public List<GameObject> Bricks = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if(child.GetComponent<Brick>())
            {
                Bricks.Add(child.gameObject);
            }
        }
    }

    void Update()
    {
        if(Bricks.Count <= 0)
        {
            RoundHandler.NextRound();
        }
    }
}
