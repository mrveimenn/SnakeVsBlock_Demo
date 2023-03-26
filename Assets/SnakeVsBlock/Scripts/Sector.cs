using System.Collections;
using UnityEngine;

namespace Assets.Scripts.HelixJump
{
    public class Sector : MonoBehaviour
    {
        private AudioSource _audio;

        private void Awake()
        {
            _audio = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _audio.Play();
            }
        }
    }
}