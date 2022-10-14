using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float minrandomValue = 1.5f;
    [SerializeField] float maxrandomValue = 3.5f;
    [SerializeField] GameObject player;
    float spawnTimer;
    float timer = 0;
    float randTimer;

    private void Start()
    {
        randTimer = Random.Range(minrandomValue, maxrandomValue);
        StartCoroutine(SpawnSpeed());
    }

    private IEnumerator SpawnSpeed()
    {
        minrandomValue = 1.5f;
        maxrandomValue = 3.5f;
        yield return new WaitForSeconds(10);
        minrandomValue = 0.5f;
        maxrandomValue = 2.5f;
        yield return new WaitForSeconds(15);
        minrandomValue = 1.5f;
        maxrandomValue = 3.5f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > randTimer)
        {
            SpawnEnemy();
            timer = spawnTimer;
            randTimer = Random.Range(minrandomValue, maxrandomValue);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.x * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
}
