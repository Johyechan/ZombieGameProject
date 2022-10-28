using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float minrandomValue = 1.5f;
    [SerializeField] float maxrandomValue = 3.5f;
    float minrandomValue2 = 1.5f;
    float maxrandomValue2 = 3.5f;
    [SerializeField] GameObject player;
    float spawnTimer;
    float timer = 0;
    float randTimer;
    bool enem2 = false;

    private void Start()
    {
        randTimer = Random.Range(minrandomValue, maxrandomValue);
        StartCoroutine(SpawnSpeed());
    }

    private IEnumerator SpawnSpeed()
    {
        minrandomValue = 3.5f;
        maxrandomValue = 5.0f;
        yield return new WaitForSeconds(15);
        minrandomValue = 2.0f;
        maxrandomValue = 3.5f;
        yield return new WaitForSeconds(15);
        minrandomValue = 1.5f;
        maxrandomValue = 2.5f;
        yield return new WaitForSeconds(5);
        minrandomValue = 2f;
        maxrandomValue = 4f;
        minrandomValue2 = 4.5f;
        maxrandomValue2 = 5.75f;
        enem2 = true;     
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
        timer += Time.deltaTime;
        if (timer > randTimer && enem2 == true)
        {
            SpawnEnemy02();
            timer = spawnTimer;
            randTimer = Random.Range(minrandomValue2, maxrandomValue2);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy[0]);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private void SpawnEnemy02()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy[1]);
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
