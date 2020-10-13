using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
   // Update is called once per frame
    void Update()
    {
        Time.timeScale=gameSpeed;
    }
}
