using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies.Detection
{
    [AddComponentMenu("ECS/Systems/" + nameof(EnemyPlayerDetectionComponent))]
    public sealed class EnemyPlayerDetectionProvider : MonoProvider<EnemyPlayerDetectionComponent>
    {
        
    }
}