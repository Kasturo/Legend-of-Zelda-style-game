using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthSlider;

    public void SetHp(int playerHp){
        healthSlider.value = playerHp;
    }

    public void SetMaxHp(int playerHp){
        healthSlider.maxValue = playerHp;
        healthSlider.value = playerHp;  
    }
}
