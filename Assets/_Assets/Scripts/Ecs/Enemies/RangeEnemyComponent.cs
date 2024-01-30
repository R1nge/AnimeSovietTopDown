using System;
using _Assets.Scripts.Enemies;
using _Assets.Scripts.Services.Enemies.Stats;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Enemies
{
    [Serializable]
    public struct RangeEnemyComponent : IComponent, IDisposable
    {
        public EnemyController enemyController;
        public BaseEnemyStats baseEnemyStats;

        public void Dispose()
        {
            enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Death);
        }
    }
}