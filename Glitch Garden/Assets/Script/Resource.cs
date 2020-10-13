using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class Resource : MonoBehaviour
{
    [SerializeField] int sunCount = 100;
    [SerializeField] TextMeshProUGUI sunText;
    private void Start()
    {
        UpdateCount();
    }
    public void UpdateCount()
    {
        sunText.text = sunCount.ToString();
    }
    public void AddSun(int amount)
    {
        sunCount += amount;
        UpdateCount();
    }
    public bool UseSun(int amount)
    {
        if (sunCount >= amount)
        {
            sunCount -= amount;
            UpdateCount();
            return true;
        }
        else
        {
            return false;
        }
   }


}
