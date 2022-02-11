using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Brick : MonoBehaviour
{
    public List<Material> colors = new List<Material>();
    [SerializeField]
    Renderer ShownBrick;

    private int health; //internal
    public int Health //property
    {
        get {
            return health;
        }
        set
        {
            health = value;
            if(Health <= 0)
            {
                if (transform.parent.GetComponent<Level>())
                {
                    var level = transform.parent.GetComponent<Level>();
                    level.Bricks.RemoveAt(level.Bricks.IndexOf(gameObject));
                }
                Destroy(gameObject);
            }
            GetComponentInChildren<BrickTextHandler>().UpdateText(Health.ToString());
            UpdateColors();
            
        }
    }

    void UpdateColors()
    {
        string strHealth = (Health).ToString();
        int wantedcolor = int.Parse(strHealth[strHealth.Length - 1].ToString());
        if(wantedcolor > colors.Count - 1)
        {
            wantedcolor = colors.Count - 1;
        }
        if(wantedcolor < 0)
        {
            wantedcolor = 0;
        }
        ShownBrick.material = colors[wantedcolor];
    }
    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector3.Distance(transform.position, worldPosition) < 0.2)
        {
            Health -= 2;
        }
    }

    void OnMouseDown()
    {
        Health -= 2;
    }
    void Start()
    {
        Health = RoundHandler.RoundNumber;
    }
}
