using System.Collections.Generic;
using _Assets.Scripts.Enemies.States;
using UnityEngine;

namespace _Assets.Scripts.Enemies
{
    public class EnemyStateMachine
    {
        private readonly Dictionary<EnemyStatesType, IEnemyState> _enemyStates;
        private EnemyStatesType _currentStateType = EnemyStatesType.Idle;
        private IEnemyState _currentState;
        
        public EnemyStatesType CurrentStateType => _currentStateType;

        public EnemyStateMachine(Animator animator)
        {
            _enemyStates = new Dictionary<EnemyStatesType, IEnemyState>
            {
                { EnemyStatesType.Idle, new IdleState(animator) },
                { EnemyStatesType.Roam, new RoamingState(animator) },
                { EnemyStatesType.Chase, new ChasingState(animator) },
                { EnemyStatesType.Attack, new AttackState(animator) },
                { EnemyStatesType.Death, new DeathState(animator)}
            };
        }

        public void Update(float deltaTime)
        {
            _currentState?.Update(deltaTime);
        }

        public void SwitchState(EnemyStatesType stateType)
        {
            if (_currentStateType == stateType)
            {
                Debug.LogWarning($"Enemy already in {stateType} state ");
                return;
            }

            _currentState?.Exit();
            _currentStateType = stateType;
            _currentState = _enemyStates[_currentStateType];
            _currentState.Enter();
        }

        public enum EnemyStatesType
        {
            Idle,
            Roam,
            Chase,
            Attack,
            Death
        }
    }
}