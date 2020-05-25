using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState{
        spawning,
        waiting,
        counting
    }

    [System.Serializable]
    public class Wave {
        public string name;
        public Transform enemy;
        public int amount;
        public float spawnRate;
    }

    public Transform[] spawnPoints;
    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float wavesCountdown;

    private float searchCountdown = 1f;

    public SpawnState spawnState;

    void Start()
    {
        wavesCountdown = timeBetweenWaves;
        spawnState = SpawnState.counting;
    }

    void Update()
    {
        if (spawnState == SpawnState.waiting) {
            if (!EnemiesAreAlive())
            {
                //Start spawning again
                BeginNewWave();
            }
            else {
                return;
            }
        }

        if (wavesCountdown <= 0)
        {
            if (spawnState != SpawnState.spawning)
            {
                StartCoroutine(SpawnWaveCo(waves[nextWave]));
            }
        }
        else {
            wavesCountdown -= Time.deltaTime;
        }
    }

    bool EnemiesAreAlive() {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0) {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
        
    }

    void BeginNewWave() {
        spawnState = SpawnState.counting;

        wavesCountdown = timeBetweenWaves;
        if ((nextWave + 1) > (waves.Length - 1))
        {
            nextWave = 0;
        }
        else {
            nextWave++;
        }
        
    }

    IEnumerator SpawnWaveCo(Wave _wave) {
        spawnState = SpawnState.spawning;
        for (int i=0; i < _wave.amount; i++) {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.spawnRate);
        }

        spawnState = SpawnState.waiting;
        yield break;
    }

    
}
