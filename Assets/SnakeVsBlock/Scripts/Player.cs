using Assets.Scripts.HelixJump;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;
    public Sector CurrentSector;
    public MainGame MainGame;
    public AudioClip AudioClip;

    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void ReachFinish()
    {
        MainGame.OnPlayerReachFinish();
        Rigidbody.velocity = Vector3.zero;
    }

    public void Bounce()
    {
        Rigidbody.velocity = new Vector3(Speed, 0, 0);
        _audio.Play();
    }

    public void Died()
    {
        MainGame.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
    }
}
