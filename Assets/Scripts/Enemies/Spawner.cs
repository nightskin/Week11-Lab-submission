using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public int MaxZombies;
    public GameObject[] zombiePrefabs;
    public  SpawnVolume[] spawnVolumes;
    private GameObject target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        for (int num = 0; num < MaxZombies; num++)
        {
            SpawnZombie();
        }
    }



    void SpawnZombie()
    {
        GameObject zombieToSpawn = zombiePrefabs[Random.Range(0, zombiePrefabs.Length)];
        SpawnVolume spawnVolume = spawnVolumes[Random.Range(0, spawnVolumes.Length)];
        GameObject zombie = Instantiate(zombieToSpawn,spawnVolume.GetPositionInBounds(), spawnVolume.transform.rotation);
        
        zombie.GetComponent<ZombieComponent>().Initialize(target);
     }
}
