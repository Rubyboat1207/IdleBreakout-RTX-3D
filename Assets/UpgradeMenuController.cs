using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenuController : MonoBehaviour
{
    public static UpgradeMenuController instance;
    public List<UpgradeButton> upgrades = new List<UpgradeButton>();
    public void OnUpgrade(UpgradeButton instance)
    {
        MoneyCounter.AddMoney(instance.cost);
        instance.cost = Mathf.FloorToInt(instance.cost * 1.5f);
        instance.costText.text = "Cost: " + instance.cost;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        instance = this;
    }
}
