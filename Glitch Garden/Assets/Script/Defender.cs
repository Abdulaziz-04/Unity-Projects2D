using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] GameObject launchPt, projectilePrefab;
    Spawner LaneX;
    //for sunFlower
    int sunCount = 15;
    [SerializeField] int Cost;

    private void Start()
    {
        SetLaneSpawners();
        
    }
    private void Update()
    {
        if (detectAttacker())
        {
            GetComponentInChildren<Animator>().SetBool("Attack", true);
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("Attack", false);
        }
        
    }
   private void SetLaneSpawners()
    {
        Spawner[] spawns= FindObjectsOfType<Spawner>();
        foreach(Spawner i in spawns)
        {
            if (Mathf.Abs(i.transform.position.y - (transform.position.y+0.5f)) < Mathf.Epsilon)
            {
                LaneX = i;
            }
        }
    }
    
    private bool detectAttacker()
    {
        if (LaneX.transform.childCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void AddSun()
    {
        FindObjectOfType<Resource>().AddSun(sunCount);
    }
    public int GetCost()
    {
        return Cost;
    }
    //Animation Events
    public void Fire(AudioClip launchSound)
    {
        Instantiate(projectilePrefab, launchPt.transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(launchSound, Camera.main.transform.position, 0.8f);
    }
    




}
