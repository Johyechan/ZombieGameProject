using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject food;
    public List<GameObject> foodList = new List<GameObject>();
    [SerializeField] Vector2 spawnArea;
    [SerializeField] public float spawnTimer;
    public float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (foodList.Count <= 0)
        {
            if (timer < 0f)
            {
                SpawnFood();
                timer = spawnTimer;
            }
        }      
        else if (timer <= 0f)
        {
            timer = 1f;
        }
    }

    public void SpawnFood()
    {
        Vector3 position = GenerateRandomPosition();
        GameObject newEnemy = Instantiate(food) as GameObject;
        foodList.Add(newEnemy);
        newEnemy.transform.position = position;
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
