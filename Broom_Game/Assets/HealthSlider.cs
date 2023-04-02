using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSlider : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public Slider slider;

    private void Start()
    {
        UpdateSlider(); 
    }

     void Update()
    {
        UpdateSlider(); 
    }

    private void UpdateSlider()
    {
        if (playerhealth != null && slider != null) 
        {
            slider.value = playerhealth.currentHealth; 
        }
    }
}
