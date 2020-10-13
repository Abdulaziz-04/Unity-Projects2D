using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSelector : MonoBehaviour
{
    [SerializeField] GameObject defenderPrefab;
    private void Start()
    {
        Text cost = GetComponentInChildren<Text>();
        if (!cost)
        {
            Debug.LogError("no cost text box found");
        }
        else
        {
            //cost.text = FindObjectOfType<Defender>().GetCost().ToString();
        }
    }
    private void OnMouseDown()
    {
        var selectors = FindObjectsOfType<DefenderSelector>();
        foreach(var i in selectors)
        {
            i.GetComponent<SpriteRenderer>().color= new Color32(46, 46, 46, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetDefender(defenderPrefab);
        
    }
}
