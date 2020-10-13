using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveconfigsList;
    //[SerializeField] Vector3 randomSpawnFactor;
    WaveConfig wave;
    int waveInd=0;
    //Just to avoid getting the boss initially
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWaves());
    }
    private IEnumerator spawnWaves()
    {
        int randomizer,i;
        while(true)
        {
            if (counter >= 5)
            {
                i=Random.Range(0, waveconfigsList.Count);
                counter = 0;

            }
            else
            {
                i = Random.Range(0, waveconfigsList.Count - 3);
            }
            if (i >= 8)
            {
                randomizer = 0;

            }
            else
            {
                randomizer = Random.Range(0, 4);
            }
            wave = waveconfigsList[i];
            counter++;
            yield return StartCoroutine(SpawnEnemies(wave,randomizer));
        }
    }
    private IEnumerator SpawnEnemies(WaveConfig wave,int randomizer)
    {
        for(var i = 0; i < wave.GetspawnCount()+randomizer; i++)
        {
            Vector3 pos = wave.GetpathPrefab()[0].transform.position;
            var spawn = Instantiate(wave.GetenemyPrefab(),pos, Quaternion.identity);
            spawn.GetComponent<Enemy>().SetWaveConfig(wave);
            yield return new WaitForSeconds(wave.GetspawnSpeed());
        }
    
    }
}
