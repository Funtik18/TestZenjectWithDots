using UnityEngine;

namespace Game.ECS
{
    public sealed class EntitySpawnerAuthoring : MonoBehaviour
    {
        public GameObject Prefab;
        public float SpawnDelay = 0.5f;
    }
}