using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Wave config")]
public class WaveConfig : ScriptableObject
{
    //Creating a wave config object which has all the required adjustments and then attaching the required prefabs
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] int spawnCount=10;
    [SerializeField] float spawnSpeed=0.5f;
    [SerializeField] float randomFactor=0.3f;
    [SerializeField] float enemySpeed=2f;

    //methods to access all the values for other scripts
    public GameObject GetenemyPrefab()
    {
        return enemyPrefab;
    }
    
    public List<Transform> GetpathPrefab()
    {
        var waypts = new List<Transform>();
        foreach(Transform i in pathPrefab.transform){
            waypts.Add(i);
        }
        return waypts;
    }

    public int GetspawnCount()
    {
        return spawnCount;
    }

    public float GetspawnSpeed()
    {
        return spawnSpeed;
    }
    public float GetrandomFactor() 
    {
        return randomFactor;
    }
    public float GetenemySpeed()
    {
        return enemySpeed;
    }


}
