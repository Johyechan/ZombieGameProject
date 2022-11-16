using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] Vector2 spawnArea;
    float minrandomValue = 1.5f;
    float maxrandomValue = 3.5f;
    float minrandomValue2;
    float maxrandomValue2;
    float minrandomValue3;
    float maxrandomValue3;
    float minrandomValue4;
    float maxrandomValue4;
    [SerializeField] GameObject player;
    float spawnTimer = 0;
    float timer = 0;
    float timer2 = 0;
    float timer3 = 0;
    float timer4 = 0;
    float randTimer;
    float randTimer2;
    float randTimer3;
    float randTimer4;
    bool enem2 = false;
    bool enem3 = false;
    bool enem4 = false;

    private void Start()
    {
        randTimer = Random.Range(minrandomValue, maxrandomValue);
        randTimer2 = Random.Range(minrandomValue2, maxrandomValue2);
        randTimer3 = Random.Range(minrandomValue3, minrandomValue3);
        randTimer4 = Random.Range(minrandomValue4, maxrandomValue4);
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
        minrandomValue = 2.5f;
        maxrandomValue = 4.5f;
        minrandomValue2 = 6.5f;
        maxrandomValue2 = 7.5f;
        enem2 = true;
        yield return new WaitForSeconds(10);
        minrandomValue = 3f;
        maxrandomValue = 5f;
        minrandomValue2 = 7f;
        maxrandomValue2 = 8f;
        yield return new WaitForSeconds(10);
        minrandomValue = 3.5f;
        maxrandomValue = 5.5f;
        minrandomValue2 = 7.5f;
        maxrandomValue2 = 8.5f;
        yield return new WaitForSeconds(5);
        minrandomValue = 4f;
        maxrandomValue = 6f;
        minrandomValue2 = 8f;
        maxrandomValue2 = 9f;
        minrandomValue3 = 5f;
        maxrandomValue3 = 6f;
        enem3 = true;
        yield return new WaitForSeconds(10);
        minrandomValue = 4.5f;
        maxrandomValue = 6.5f;
        minrandomValue2 = 8.5f;
        maxrandomValue2 = 9.5f;
        minrandomValue3 = 5.5f;
        maxrandomValue3 = 6.5f;
        yield return new WaitForSeconds(10);
        minrandomValue = 4.5f;
        maxrandomValue = 6.5f;
        minrandomValue2 = 8.5f;
        maxrandomValue2 = 9.5f;
        minrandomValue3 = 5.5f;
        maxrandomValue3 = 6.5f;
        minrandomValue4 = 10f;
        maxrandomValue4 = 11f;
        enem4 = true;
        yield return new WaitForSeconds(10);
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

        timer2 += Time.deltaTime;
        if (timer2 > randTimer2 && enem2 == true)
        {
            SpawnEnemy02();
            timer2 = spawnTimer;
            randTimer2 = Random.Range(minrandomValue2, maxrandomValue2);
        }

        timer3 += Time.deltaTime;
        if(timer3 > randTimer3 && enem3 == true)
        {
            SpawnEnemy03();
            timer3 = spawnTimer;
            randTimer3 = Random.Range(minrandomValue3, maxrandomValue3);
        }
        timer4 += Time.deltaTime;
        if (timer4 > randTimer4 && enem4 == true)
        {
            SpawnEnemy04();
            timer4 = spawnTimer;
            randTimer4 = Random.Range(minrandomValue4, maxrandomValue4);
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

    private void SpawnEnemy03()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy[2]);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }
    private void SpawnEnemy04()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy[3]);
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
            position.x = UnityEngine.Random.Range(-spawnArea.x - 8, spawnArea.x + 8);
            position.y = spawnArea.x * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y - 8, spawnArea.y + 8);
            position.x = spawnArea.x * f;
        }

        position.z = 0;

        return position;
    }
}
