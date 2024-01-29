using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Animations
{
    [Serializable]
    public struct AnimationComponent : IComponent
    {
        public Animator animator;
    }
}