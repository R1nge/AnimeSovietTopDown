using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Attack
{
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EnemyAttackSystem))]
    public sealed class EnemyAttackSystem : UpdateSystem
    {
        public override void OnAwake()
        {
            
        }

        public override void OnUpdate(float deltaTime)
        {
        }
    }
}