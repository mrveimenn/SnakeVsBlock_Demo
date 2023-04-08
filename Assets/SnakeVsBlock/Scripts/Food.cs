using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int Amount { get; private set; }

    [SerializeField]
    private int minAmount = 1;
    [SerializeField]
    private int maxAmount = 6;

    private void Start()
    {
        Amount = Random.Range(minAmount, maxAmount);
    }
}
