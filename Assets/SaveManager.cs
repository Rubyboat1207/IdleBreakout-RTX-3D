using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    float autoSaveTimer = 0;
    float SaveTime = 20;
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            new SaveFile(File.ReadAllText(Application.persistentDataPath + "/saveData.json")).LoadSave();
        }
        catch
        {
            Save();
        }
    }

    void Save()
    {
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", new SaveFile().getJson());
    }

    // Update is called once per frame
    void Update()
    {
        autoSaveTimer += Time.deltaTime;
        if(autoSaveTimer > SaveTime)
        {
            Save();
        }

    }
}

public class SaveFile
{
    public int basicBallCount = 0;
    public int sniperBallCount = 0;
    public int money = 0;
    public int currentLevel = 0;
    public int clickUpgradeLevel = 0;

    public SaveFile(int basicBallCount, int sniperBallCount, int money, int currentLevel, int clickUpgradeLevel)
    {
        this.basicBallCount = basicBallCount;
        this.sniperBallCount = sniperBallCount;
        this.money = money;
        this.currentLevel = currentLevel;
        this.clickUpgradeLevel = clickUpgradeLevel;
    }

    public SaveFile()
    {
        this.basicBallCount = BasicBall.balls.Count;
        this.sniperBallCount = SniperBall.balls.Count;
        money = MoneyCounter.money;
        currentLevel = RoundHandler.RoundNumber;
        clickUpgradeLevel = UpgradeMenuController.instance.upgrades[0].count;
    }

    public void LoadSave()
    {
        for(int i = 0; i < basicBallCount; i++)
        {
            GameObject.Instantiate(Resources.Load<GameObject>("basic ball"));
        }
        for (int i = 0; i < sniperBallCount; i++)
        {
            GameObject.Instantiate(Resources.Load<GameObject>("sniper ball"));
        }
        RoundHandler.RoundNumber = currentLevel;
        MoneyCounter.money = money;
        UpgradeMenuController.instance.upgrades[0].count = clickUpgradeLevel;

    }

    public string getJson()
    {
        return JsonUtility.ToJson(this);
    }

    public SaveFile(string json)
    {
        SaveFile save = JsonUtility.FromJson<SaveFile>(json);
        basicBallCount = save.basicBallCount;
        sniperBallCount = save.sniperBallCount;
        money = save.money;
        currentLevel = save.currentLevel;
        clickUpgradeLevel = save.clickUpgradeLevel;
    }
}
