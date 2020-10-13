using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numOfAttackers = 0;
    bool timerFinished = false;
    public void AttackerSpawned()
    {
        numOfAttackers++;
    }
    private void Start()
    {

        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    public void AttackerKilled()
    {
        numOfAttackers--;
        if(numOfAttackers<=0 && timerFinished)
        {
            StartCoroutine(LoadLevelWin());

        }
    }
    IEnumerator LoadLevelWin()
    {

        if (loseLabel.activeSelf)
        {
            winLabel.SetActive(false);
        }
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        FindObjectOfType<MusicMgmt>().GetComponent<AudioSource>().Pause();
        yield return new WaitForSeconds(3f);
        FindObjectOfType<SceneMgmt>().LoadStartScene();

    }
    public void LoadLevelLost()
    {
        loseLabel.SetActive(true);
        StopSpawning();
        FindObjectOfType<MusicMgmt>().GetComponent<AudioSource>().Pause();
    }
    public void TimerFinished()
    {
        timerFinished = true;
        StopSpawning();
    }
    public void StopSpawning()
    {
        Spawner[] arr = FindObjectsOfType<Spawner>();
        foreach(Spawner i in arr)
        {
            i.StopSpawning();
        }
    }
    
}
