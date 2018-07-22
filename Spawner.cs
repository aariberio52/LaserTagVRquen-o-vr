using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public Enemy enemy;
    public Wave[] waves;

    Wave currentWave;
    int currentWaveNumber=0;

    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;

     void Start ()
    {
        NextWave();
    }

    void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
            int index = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[index].transform.position;

            Enemy spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;
         if (enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        print("Wave: " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length) 
        {
            currentWave = waves[currentWaveNumber - 1];

            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }
    }

    [System.Serializable]
    public class Wave {

        public int enemyCount;
        public float timeBetweenSpawns;
  }
}
