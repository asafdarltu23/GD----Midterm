using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI HealthText;

    void Update()
    {
        HealthText.text = HealthScript.Health.ToString() + " / " + HealthScript.maxHealth.ToString();
    }

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }
}
