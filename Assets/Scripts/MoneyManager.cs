using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static float money;
    public TextMeshProUGUI moneyText;
    // Start is called before the first frame update
    void Start()
    {
        money = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + money;
    }
}
