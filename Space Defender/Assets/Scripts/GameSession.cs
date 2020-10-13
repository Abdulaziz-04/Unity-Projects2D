using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;
    private void Awake()
    {
        SetupSingleton();
        
    }
    public void SetupSingleton()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public  int GetScore()
    {
        return score;

    }
    public void AddtoScore(int val)
    {
        score += val;

    }
    public void resetScore()
    {
        Destroy(gameObject);
    }

}
