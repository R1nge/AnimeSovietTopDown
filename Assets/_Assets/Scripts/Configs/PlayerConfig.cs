using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "Configs/Player Config")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private GameObject playerPrefab;
        public GameObject PlayerPrefab => playerPrefab;
    }
}