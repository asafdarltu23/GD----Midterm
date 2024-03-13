using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeTextScript : MonoBehaviour
{
    public bool AssaultText;
    public bool BankText;

    public TextMeshProUGUI upgradeCostText;
    // Start is called before the first frame update
    void Start()
    {
        if (AssaultText)
            upgradeCostText.text = "$" + TowerScript.upgradeCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (AssaultText)
            upgradeCostText.text = "$" + TowerScript.upgradeCost.ToString();
    }
}
