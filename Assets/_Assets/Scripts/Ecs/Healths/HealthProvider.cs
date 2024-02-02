using Scellecs.Morpeh.Providers;

namespace _Assets.Scripts.Ecs.Healths
{
    public class HealthProvider : MonoProvider<HealthComponent>
    {
        public void Heal(int amount)
        {
            if (amount <= 0)
            {
                return;
            }
            
            GetData().health += amount;
        }
    }
}