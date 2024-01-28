﻿using UnityEngine;

namespace _Assets.Scripts.Enemies.States
{
    public class AttackState : IEnemyState
    {
        public readonly Animator Animator;
        
        public AttackState(Animator animator)
        {
            Animator = animator;
        }
        
        public void Enter()
        {
            Debug.Log("Enter attack state");
        }

        public void Update(float deltaTime)
        {
            
        }

        public void Exit()
        {
            Debug.Log("Exit attack state");
        }
    }
}