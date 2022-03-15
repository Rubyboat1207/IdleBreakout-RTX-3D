using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    public static int money;
    public static void AddMoney(int Money)
    {
        money += Money;
    }
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "$" + money;
    }
}
