using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float spawnInterval;
 
    [SerializeField] float minSpawnInterval;

    [SerializeField] float openDoorInterval;

    [SerializeField] float spawnTimeDecreaseOverTime;
    [SerializeField] float decreaseInterval;

    [SerializeField] GameObject enemyToSpawn;

    [SerializeField] Transform spawnPoint;

    [SerializeField] Animator anim;

    private float timeToDecrease;
    private float timeToSpawn;
    private float timeToClose;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        timeToDecrease = Time.time + decreaseInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToSpawn)
        {
            SpawnEnemy();
        }


        if(Time.time > timeToDecrease)
        {
            spawnInterval -= spawnTimeDecreaseOverTime;
            timeToDecrease = Time.time + decreaseInterval;
        }

        if(Time.time > timeToClose)
        {
            anim.SetBool("IsOpen", false);
        }
    }


    void SpawnEnemy()
    {
        timeToSpawn = Time.time + spawnInterval;

        GameObject enemy = Instantiate(
                 enemyToSpawn,
                 spawnPoint.position,
                 spawnPoint.rotation
             );

        
        timeToClose = Time.time + openDoorInterval;

        anim.SetBool("IsOpen", true);
    }
}
