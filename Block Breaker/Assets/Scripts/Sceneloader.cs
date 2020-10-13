using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currindex = SceneManager.GetActiveScene().buildIndex;
        AudioSource aud = FindObjectOfType<AudioSource>();
        if (FindObjectOfType<Initiate>())
        {
            GameObject ball = FindObjectOfType<Initiate>().gameObject;
            Destroy(ball);
        }
       DontDestroyOnLoad(aud);
        SceneManager.LoadScene(currindex + 1);
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<Level>().ResetGame();
    }
    public void  Quit()
    {
        Application.Quit(); 
    }
}
