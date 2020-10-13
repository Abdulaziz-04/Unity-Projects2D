using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMgmt : MonoBehaviour
{
    [SerializeField] Image healthBar;
    
    public void SetHealth(float health,float startHealth)
    {
        healthBar.fillAmount = health/startHealth;

    }
}
