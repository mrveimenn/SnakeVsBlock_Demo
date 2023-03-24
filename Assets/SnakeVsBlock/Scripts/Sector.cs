using System.Collections;
using UnityEngine;

namespace Assets.Scripts.HelixJump
{
    public class Sector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.Died();
            }
        }
    }
}