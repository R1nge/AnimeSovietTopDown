using System;
using UnityEngine;

namespace _Assets.Scripts.Services
{
    public class EnemyWavesService : MonoBehaviour
    {
        [SerializeField] private Wave[] waves;
        public Wave[] Waves => waves;
    }

    [Serializable]
    public class Wave
    {
        public EnemyWave[] waves;
    }
}