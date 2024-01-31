using System;
using _Assets.Scripts.Enemies;
using _Assets.Scripts.Services.Enemies.Stats;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Enemies
{
    [Serializable]
    public struct RangeEnemyComponent : IComponent, IDisposable
    {
        public Transform shootPoint;
        public EnemyController enemyController;
        //TODO: move to a separate component
        public BaseEnemyStats baseEnemyStats;
        public RangeEnemyStats rangeEnemyStats;

        public void Dispose()
        {
            enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Death);
        }
    }
}