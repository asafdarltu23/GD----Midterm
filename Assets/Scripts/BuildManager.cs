using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject currentTower;
    public GameObject autoSelectedTower;
    public GameObject assaultTower;
    public GameObject bankTower;

    public static int currentTowerLimit;
    public static int currentTowerCost;
    public static int currentTowerUpgradeCost;


    public static BuildManager instance;

    public GameObject noBuildtext;
    public static GameObject noBuildtextRef;

    public GameObject GetTower() 
    { 
        return currentTower; 
    }

    private void Start()
    {
        currentTower = autoSelectedTower;
        noBuildtextRef = noBuildtext;
    }

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogError("Multiple BuildManager scripts");
            return;
        }
        instance = this;
    }

    public void AssaultSelected()
    {
        if (TowerPlacement.isBuilding == true)
            return;

        TowerPlacement.isBuilding = true;
        currentTower = assaultTower;
        currentTowerLimit = 8;
        currentTowerCost = 1000;
    }

    public void BankSelected()
    {
        if (TowerPlacement.isBuilding == true)
            return;

        TowerPlacement.isBuilding = true;
        currentTower = bankTower;
        currentTowerLimit = 1;
        currentTowerCost = 2000;
    }
}
