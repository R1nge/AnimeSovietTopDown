using UnityEngine;

namespace _Assets.Scripts.Services.UIs.HealthBar
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField] private HealthBarView healthBarView;

        public void UpdateHealthBar(int health, int maxHealth)
        {
            healthBarView.UpdateHealthBar(health, maxHealth);
        }
    }
}