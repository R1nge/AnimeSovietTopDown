using System;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;

namespace _Assets.Scripts.Ecs.Enemies
{
    [Serializable]
    public struct EnemyMarkerComponent : IComponent, IDisposable
    {
        public EnemyController enemyController;
        public void Dispose()
        {
            enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Death);
        }
    }
}