using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SpawnBall : MonoBehaviour, IPointerClickHandler {
    [SerializeField]
    Ball Balltype;
    public int cost;
    public TextMeshProUGUI costText;

    private void Start()
    {
        costText.text = "$" + cost;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(MoneyCounter.money < cost)
        {
            return;
        }
        var ball = Instantiate(Balltype);
        ball.transform.position = new Vector3(0, 0, 0);
        MoneyCounter.AddMoney(-cost);
        cost = (int)(cost * 1.5);
        costText.text = "$" + cost;
    }
}
