using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpSlider : MonoBehaviour
{
    public PlayerMovement playerXP;
    public Slider slider;

    public float newMaxValue;

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
        if (playerXP != null && slider != null)
        {
            slider.value = playerXP.currentExp;
        }
        if (playerXP.Level1 == true)
        {
            slider.maxValue = 10f;
        }
        if (playerXP.Level2 == true)
        {
           slider.maxValue = 50f;
        }
    }
}

