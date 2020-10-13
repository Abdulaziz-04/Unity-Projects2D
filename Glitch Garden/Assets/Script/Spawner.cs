using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Attacker[] enemyPrefab;
    int enemyInd;
    [SerializeField] float minSpawntime = 5f;
    [SerializeField] float maxSpawntime = 1f;
    bool spawn=true;
    //Enemy spawner
    IEnumerator Start()
    {
        while (spawn)
        {
            enemyInd = Random.Range(0, enemyPrefab.Length);
            yield return new WaitForSeconds(Random.Range(maxSpawntime, minSpawntime));
            Attacker newAttacker=Instantiate(enemyPrefab[enemyInd], transform.position, transform.rotation) as Attacker;
            //Set its instantiation under the parent to keep the child count in each lane
            newAttacker.transform.parent = transform;
        }
    }
    public void StopSpawning()
    {
        spawn = false;
    }
}
