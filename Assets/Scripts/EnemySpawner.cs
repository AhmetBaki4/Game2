using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private GameObject  _enemy;
    private float _spawnTimer = 2f;
    private float _spawnRateIncrease = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNextEnemy());
        StartCoroutine(SpawnRateIncrease());
        
    }

    IEnumerator SpawnNextEnemy()
    {
        int nextSpawnLocation = Random.Range(0, _spawnPoints.Length);
        Instantiate(_enemy, _spawnPoints[nextSpawnLocation].transform.position, Quaternion.identity);
        yield return new WaitForSeconds( _spawnTimer);

        if (!_gameManager._gameOver)
        { 
            StartCoroutine(SpawnNextEnemy());
        }
    }
    
    IEnumerator SpawnRateIncrease()
    {
        yield return new WaitForSeconds( _spawnRateIncrease);
        
        if (_spawnTimer >=0.5f)
        {
            _spawnTimer -= 0.2f;
        }
        StartCoroutine(SpawnRateIncrease());
    }
}
