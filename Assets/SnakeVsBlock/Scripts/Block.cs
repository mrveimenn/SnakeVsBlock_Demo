using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    public Text hitpointText;
    public ParticleSystem BoomSystem;
    public int Hitpoints { get; private set; }
    public int MaxHitpoints { get { return maxHitpoints;} }

    [SerializeField]
    private int minHitpoints = 1;
    [SerializeField]
    private int maxHitpoints = 5;

    private void Start()
    {
        Hitpoints = Random.Range(minHitpoints, maxHitpoints);
        hitpointText.text = Hitpoints.ToString();
    }

    public void ApplyDamage()
    {
        Hitpoints--;
        hitpointText.text = Hitpoints.ToString();

        if (Hitpoints <= 0)
        {
            Collapse();
        }
    }

    private void Collapse()
    {
        Destroy(gameObject);
    }
}