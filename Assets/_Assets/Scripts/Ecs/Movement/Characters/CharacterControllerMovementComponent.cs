using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement
{
    [Serializable]
    public struct CharacterControllerMovementComponent : IComponent
    {
        public CharacterController characterController;
        public Vector3 direction;
        public float speed;
    }
}