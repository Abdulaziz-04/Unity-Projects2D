using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgmt : MonoBehaviour
{
    int currentIndex;
    int loadTime = 3;
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentIndex == 0)
        {
            StartCoroutine(WaitforLoad());
        }
    }
    IEnumerator WaitforLoad()
    {
        yield return new WaitForSeconds(loadTime);
        LoadNextScene();

    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentIndex + 1);
        if (!FindObjectOfType<MusicMgmt>().GetComponent<AudioSource>().isPlaying)
        {
            FindObjectOfType<MusicMgmt>().GetComponent<AudioSource>().Play();
        }

    }
    public void LoadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        if (!FindObjectOfType<MusicMgmt>().GetComponent<AudioSource>().isPlaying)
        {
            FindObjectOfType<MusicMgmt>().GetComponent<AudioSource>().Play();
        }
    }
}
