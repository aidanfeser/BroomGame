using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject panal;

    public void LevelUpButton()
    {
        BasicShooting shootingScript = FindObjectOfType<BasicShooting>();
        Debug.Log("clicked");

        if (shootingScript == null)
        {
            Debug.Log("shootingScript is null!");
        }
        panal.SetActive(false);

        Time.timeScale = 1f;

        
        shootingScript.canShoot = true;

       
    }
}
