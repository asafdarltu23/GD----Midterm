using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Renderer render;
    private Color startColor;

    public static bool isBuilding = false;

    public GameObject tower;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        startColor = render.material.color;
    }

    private void OnMouseEnter()
    {
        if (isBuilding == true)
            render.material.color = Color.green;
    }

    private void OnMouseExit()
    {
        render.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Cant build");
            return;
        }

        if (isBuilding == true && GameObject.FindGameObjectsWithTag(BuildManager.currentTower.tag).Length < BuildManager.currentTowerLimit && MoneyManager.money >= BuildManager.currentTowerCost)
        {
            GameObject currentTower = BuildManager.instance.GetTower();
            tower = (GameObject)Instantiate(currentTower, new Vector3(transform.position.x, 3.46f, transform.position.z), transform.rotation);
            MoneyManager.money = MoneyManager.money - BuildManager.currentTowerCost;
        }
        else if (isBuilding == true)
        {
            Debug.Log("Maximum Reached");
            StartCoroutine(FlashText());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
            isBuilding = false;
    }

    IEnumerator FlashText()
    {
        BuildManager.noBuildtextRef.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        BuildManager.noBuildtextRef.SetActive(false);
    }
}
