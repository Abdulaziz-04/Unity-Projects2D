using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMgmt : MonoBehaviour
{
    private void Awake()
    {
        //To mainatain uninterrupted music on loading scenes
        SetMusic();

    }
    private void SetMusic()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    }
