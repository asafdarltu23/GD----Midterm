using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankerScript : MonoBehaviour
{
    public static float bonusCash = 250;

    private float maxUpgrade = 5;
    private float level = 1;

    public static float upgradeCost = 2000;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateStats", 0, 0.5f);
    }

    void UpdateStats()
    {
        if (level == 1)
        {
            bonusCash = 500;
        }

        if (level == 2)
        {
            bonusCash = 1000;
        }

        if (level == 3)
        {
            bonusCash = 1500;
        }

        if (level == 4)
        {
            bonusCash = 2000;
        }

        if (level == 5)
        {
            bonusCash = 3000;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BankUpgrade()
    {
        if (level > 1)
            upgradeCost = 2000 * (level + 1);

        if (level < maxUpgrade && MoneyManager.money >= upgradeCost)
        {
            level++;
            MoneyManager.money = MoneyManager.money - upgradeCost;
        }
        else if (level >= maxUpgrade)
        {
            Debug.Log("Maximum Upgrade!");
        }
    }
}
