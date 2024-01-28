using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Rotation
{
    [Serializable]
    public struct RotationComponent : IComponent
    {
        public Transform transform;
        public Quaternion rotation;
    }
}