using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthBarObject;

    void SetSize()
    {
        Debug.Log("Health Bar: " + GameManager.health + "/ " + GameManager.healthCap);
        HealthBarObject.value = GameManager.health / GameManager.healthCap;
    }

    private void OnEnable()
    {
        Health.PlayerHealthUpdated += SetSize;
    }

    private void OnDisable()
    {
        Health.PlayerHealthUpdated -= SetSize;
    }

    public void OnSliderChanging(float sliderValue)
    {
        Debug.Log("Slider Changed Value to: " + sliderValue);
    }
}
