using System.Collections.Generic;
using _Assets.Scripts.Enemies.States;
using _Assets.Scripts.Misc;
using UnityEngine;

namespace _Assets.Scripts.Enemies
{
    public class EnemyStateMachine
    {
        private readonly IMyLogger _logger;
        private readonly Dictionary<EnemyStatesType, IEnemyState> _enemyStates;
        private EnemyStatesType _currentStateType = EnemyStatesType.Idle;
        private IEnemyState _currentState;
        
        public EnemyStatesType CurrentStateType => _currentStateType;

        public EnemyStateMachine(Animator animator, EnemyDeathController enemyDeathController, IMyLogger logger)
        {
            _logger = logger;
            _enemyStates = new Dictionary<EnemyStatesType, IEnemyState>
            {
                { EnemyStatesType.Idle, new IdleState(animator, logger) },
                { EnemyStatesType.Roam, new RoamingState(animator) },
                { EnemyStatesType.Chase, new ChasingState(animator, logger) },
                { EnemyStatesType.Attack, new AttackState(animator, logger) },
                { EnemyStatesType.Death, new DeathState(animator, enemyDeathController)}
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
                _logger.LogWarning($"Enemy already in {stateType} state");
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