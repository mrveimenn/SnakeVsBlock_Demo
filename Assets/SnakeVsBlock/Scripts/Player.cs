using Assets.Scripts.HelixJump;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public Rigidbody Rigidbody;
    public Sector CurrentSector;
    public MainGame MainGame;
    public AudioClip Finish;
    public AudioClip Death;

    private AudioSource _audio;

    public void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void ReachFinish()
    {
        MainGame.OnPlayerReachFinish();
        Rigidbody.velocity = Vector3.zero;
        _audio.PlayOneShot(Finish);
    }

    public void Died()
    {
        MainGame.OnPlayerDied();
        Rigidbody.velocity = Vector3.zero;
        _audio.PlayOneShot(Death);
    }
}
