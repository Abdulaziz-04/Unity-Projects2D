using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] int blocks;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score=0;
    //cached params
    Sceneloader scene;
    private void Awake()
    {
        
        if (FindObjectsOfType<Level>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scene = FindObjectOfType<Sceneloader>();
        scoreText.text = score.ToString();
    }
    public void BlockPlus()
    {
        blocks++;
    }
    public void BlockMinus()
    {
        blocks--;
        if (blocks <= 0)
        {
            scene.LoadNextScene();
        }
    }
    public void AddScore()
    {
        if (tag == "1-hit")
        {
            score += 20;

        }
        else if (tag == "2-hit")
        {
            score += 40;
                
        }
        else
        {
            score += 70;

        }
        scoreText.text = score.ToString();
    }
    public int getScore()
    {
        return score;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
        Destroy(FindObjectOfType<AudioListener>());
        Destroy(FindObjectOfType<AudioSource>());
    }
    
}
