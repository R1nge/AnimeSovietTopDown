using System;
using _Assets.Scripts.Enemies;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace _Assets.Scripts.Ecs.Enemies
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [Serializable]
    public struct EnemyBaseComponent : IComponent, IDisposable
    {
        public EnemyController enemyController;

        public void Dispose() => enemyController.EnemyStateMachine.SwitchState(EnemyStateMachine.EnemyStatesType.Death);
    }
}