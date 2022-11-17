using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;

    [SerializeField] Vector2 spawnArea;

    float minrandomValue = 5f;
    float maxrandomValue = 7f;
    float minrandomValue2 = 8.5f;
    float maxrandomValue2 = 9.5f;
    float minrandomValue3 = 5f;
    float maxrandomValue3 = 6f;
    float minrandomValue4 = 10.5f;
    float maxrandomValue4 = 11.5f;
    float minrandomValue5 = 12f;
    float maxrandomValue5 = 13f;

    [SerializeField] GameObject player;

    float spawnTimer = 0;

    float timer = 0;
    float timer2 = 0;
    float timer3 = 0;
    float timer4 = 0;
    float timer5 = 0;

    float randTimer;
    float randTimer2;
    float randTimer3;
    float randTimer4;
    float randTimer5;

    bool enem2 = false;
    bool enem3 = false;
    bool enem4 = false;
    bool enem5 = false;

    float minValue = 0.5f;
    float waitTime = 15f;
    private void Start()
    {
        randTimer = Random.Range(minrandomValue, maxrandomValue);
        randTimer2 = Random.Range(minrandomValue2, maxrandomValue2);
        randTimer3 = Random.Range(minrandomValue3, minrandomValue3);
        randTimer4 = Random.Range(minrandomValue4, maxrandomValue4);
        randTimer5 = Random.Range(minrandomValue5, maxrandomValue5);
        StartCoroutine(SpawnSpeed());
    }

    private IEnumerator SpawnSpeed()
    {
        yield return new WaitForSeconds(waitTime);
        minrandomValue -= minValue;
        maxrandomValue -= minValue;
        yield return new WaitForSeconds(waitTime);
        minrandomValue -= minValue;
        maxrandomValue -= minValue;
        yield return new WaitForSeconds(waitTime);
        minrandomValue -= minValue;
        maxrandomValue -= minValue;
        minrandomValue2 -= minValue;
        maxrandomValue2 -= minValue;
        enem2 = true;
        yield return new WaitForSeconds(waitTime);
        minrandomValue -= minValue;
        maxrandomValue -= minValue;
        minrandomValue2 -= minValue;
        maxrandomValue2 -= minValue;
        yield return new WaitForSeconds(waitTime);
        minrandomValue -= minValue;
        maxrandomValue -= minValue;
        minrandomValue2 -= minValue;
        maxrandomValue2 -= minValue;
        yield return new WaitForSeconds(waitTime);
        minrandomValue -= minValue;
        maxrandomValue -= minValue;
        minrandomValue2 -= minValue;
        maxrandomValue2 -= minValue;
        minrandomValue3 -= minValue;
        maxrandomValue3 -= minValue;
        enem3 = true;
        yield return new WaitForSeconds(waitTime);
        minrandomValue -= minValue;
        maxrandomValue -= minValue;
        minrandomValue2 -= minValue;
        maxrandomValue2 -= minValue;
        minrandomValue3 -= minValue;
        maxrandomValue3 -= minValue;
        minrandomValue4 -= minValue;
        maxrandomValue4 -= minValue;
        enem4 = true;
        yield return new WaitForSeconds(waitTime);
        minrandomValue -= minValue;
        maxrandomValue -= minValue;
        minrandomValue2 -= minValue;
        maxrandomValue2 -= minValue;
        minrandomValue3 -= minValue;
        maxrandomValue3 -= minValue;
        minrandomValue4 -= minValue;
        maxrandomValue4 -= minValue;
        minrandomValue5 -= minValue;
        maxrandomValue5 -= minValue;
        enem5 = true;
        yield return new WaitForSeconds(waitTime);
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
        timer5 += Time.deltaTime;
        if (timer5 > randTimer5 && enem5 == true)
        {
            SpawnEnemy05();
            timer5 = spawnTimer;
            randTimer5 = Random.Range(minrandomValue5, maxrandomValue5);
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
    private void SpawnEnemy05()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        GameObject newEnemy = Instantiate(enemy[4]);
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
