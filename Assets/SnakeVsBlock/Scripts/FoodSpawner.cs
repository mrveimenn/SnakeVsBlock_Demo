using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public GameObject road;
    public int minFood = 1;
    public int maxFood = 5;

    private void Start()
    {
        SpawnFood();
    }

    private void SpawnFood()
    {
        int foodCount = Random.Range(minFood, maxFood + 1);
        Vector3 roadSize = road.GetComponent<Renderer>().bounds.size;

        for (int i = 0; i < foodCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-5, 100),
                                           0.5f,
                                           Random.Range(-4f, 4f));
            Quaternion newRotation = Quaternion.Euler(90f, 0f, 0f);
            foodPrefab.transform.rotation = newRotation;

            Instantiate(foodPrefab, position, newRotation);
        }
    }
}
