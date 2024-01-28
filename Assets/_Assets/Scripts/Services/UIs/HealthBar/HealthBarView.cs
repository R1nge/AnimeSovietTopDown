using UnityEngine;
using UnityEngine.UI;

namespace _Assets.Scripts.Services.UIs.HealthBar
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;

        public void UpdateHealthBar(int health, int maxHealth)
        {
            healthBar.value = (float)health / maxHealth;
        }
    }
}