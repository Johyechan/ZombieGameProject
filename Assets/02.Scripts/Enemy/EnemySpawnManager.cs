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
    [SerializeField] GameObject player;
    float spawnTimer;
    float timer = 0;
    float timer2 = 0;
    float randTimer;
    float randTimer2;
    bool enem2 = false;

    Camera cam;

    private void Start()
    {
        cam = UnityEngine.Camera.main;
        randTimer = Random.Range(minrandomValue, maxrandomValue);
        randTimer2 = Random.Range(minrandomValue2, maxrandomValue2);
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
        minrandomValue = 2f;
        maxrandomValue = 3f;
        minrandomValue2 = 7f;
        maxrandomValue2 = 8f;
    }

    private void Update()
    {
        DestroyEnemiesInCamera();
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
    }

    public void DestroyEnemiesInCamera()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            Vector3 viewPos = cam.WorldToScreenPoint(enemy[i].transform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {
                Debug.Log($"Camer in Object : {enemy[i].name}");
            }
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
