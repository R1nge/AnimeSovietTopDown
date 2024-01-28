using System.Collections.Generic;
using _Assets.Scripts.Players.States;
using UnityEngine;

namespace _Assets.Scripts.Players
{
    public class PlayerStateMachine
    {
        private readonly Dictionary<PlayerStatesType, IPlayerState> _enemyStates;
        private PlayerStatesType _currentStateType = PlayerStatesType.Idle;
        private IPlayerState _currentState;
        
        public PlayerStatesType CurrentStateType => _currentStateType;

        public PlayerStateMachine(Animator animator)
        {
            _enemyStates = new Dictionary<PlayerStatesType, IPlayerState>
            {
                { PlayerStatesType.Idle, new IdleState(animator) },
                { PlayerStatesType.Moving, new MovingState(animator) },
                { PlayerStatesType.Attacking, new AttackState(animator) }
            };
        }

        public void Update(float deltaTime)
        {
            _currentState?.Update(deltaTime);
        }

        public void SwitchState(PlayerStatesType stateType)
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

        public enum PlayerStatesType
        {
            Idle,
            Moving,
            Attacking
        }
    }
}