using UnityEngine;

namespace _Assets.Scripts.Enemies
{
    public class EnemyDeathController : MonoBehaviour
    {
        [SerializeField] private new Collider collider;

        public void Die()
        {
            collider.enabled = false;
        }
    }
}