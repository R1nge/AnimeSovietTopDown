﻿using System.Collections.Generic;
using UnityEngine;

namespace _Assets.Scripts.Services.StateMachine
{
    public class GameStateMachine
    {
        private readonly Dictionary<GameStateType, IGameState> _states;
        private IGameState _currentGameState;
        private GameStateType _currentGameStateType;

        public GameStateMachine(GameStatesFactory gameStatesFactory)
        {
            _states = new Dictionary<GameStateType, IGameState>
            {
                { GameStateType.Init, gameStatesFactory.CreateInitState(this) },
                { GameStateType.Game, gameStatesFactory.CreateGameState(this) },
                { GameStateType.WaveStarted, gameStatesFactory.CreateWaveStartedState(this) },
                { GameStateType.WaveEnded, gameStatesFactory.CreateWaveEndedState(this) },
                { GameStateType.GameOver, gameStatesFactory.CreateGameOverState(this) }
            };
        }

        public void SwitchState(GameStateType gameStateType)
        {
            if (_currentGameStateType == gameStateType)
            {
                Debug.LogWarning("Current state is already " + gameStateType);
                return;
            }

            _currentGameState?.Exit();
            _currentGameState = _states[gameStateType];
            _currentGameStateType = gameStateType;
            _currentGameState.Enter();
        }
    }
}