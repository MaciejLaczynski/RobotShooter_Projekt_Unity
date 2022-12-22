using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health;
    public Image fillImage;
    private Slider slider;


    void Awake()
    {
        slider = GetComponent<Slider>();
    }


    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if(slider.value < slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillvalue = health.currentHealth / health.startingHealth;
        slider.value = fillvalue;
    }
}
