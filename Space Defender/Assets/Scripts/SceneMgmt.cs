using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgmt : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().resetScore();
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadEndscreen()
    {
        StartCoroutine(WaitAndLoad());
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);

    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
