using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreMgmt : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameSession gs;
    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gs = FindObjectOfType<GameSession>();
    }
    private void Update()
    {
        scoreText.text = gs.GetScore().ToString();
    }


}


