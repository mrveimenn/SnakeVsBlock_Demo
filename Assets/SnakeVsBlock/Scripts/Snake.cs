using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snakeSegmentPrefab;
    public int initialSnakeLength = 3;
    public GameObject food;

    public List<Transform> segments = new List<Transform>();

    private List<Vector2> snakeSegments = new List<Vector2>();

    private void Start()
    {
        for (int i = 0; i < initialSnakeLength; i++)
        {
            snakeSegments.Add(new Vector2(i, 0));
            Instantiate(snakeSegmentPrefab, new Vector3(i, 0, 0), Quaternion.identity);
        }
    }

    private void Update()
    {
        if (food != null && Vector3.Distance(transform.position, food.transform.position) < 0.5f)
        {
            Destroy(food);
            AddSegment();
        }

        for (int i = 0; i < snakeSegments.Count; i++)
        {
            GameObject segmentObject = GetSnakeSegmentObject(i);
            segmentObject.transform.position = new Vector3(snakeSegments[i].x, snakeSegments[i].y, 0);
        }
    }

    private void AddSegment()
    {
        GameObject newSegmentObject = Instantiate(snakeSegmentPrefab, transform.position, Quaternion.identity);
        segments.Add(newSegmentObject.transform);
    }

    private GameObject GetSnakeSegmentObject(int index)
    {
        return transform.GetChild(index).gameObject;
    }
}
