using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float time = 10f;
    bool trigger = false;
    private void Update()
    {
        if (trigger) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / time;
        bool timerFinished = Time.timeSinceLevelLoad >= time;
        if (timerFinished)
        {
            FindObjectOfType<LevelController>().TimerFinished();
            trigger = true;
            //for loading scenes there might be some time lag so adding a bool var
        }
        
    }
    private void stopAnimation()
    {
        if (GetComponent<Slider>().value == 1)
        {

            GetComponent<Animator>().speed = 0;

        }

    }

}
