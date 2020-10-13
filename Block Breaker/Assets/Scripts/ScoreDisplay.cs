using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    private void Update()
    {
        finalScore.text = FindObjectOfType<Level>().getScore().ToString();

    }

}
