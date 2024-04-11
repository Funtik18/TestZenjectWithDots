using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS
{
    public struct EntitySpawner : IComponentData
    {
        public double NextSpawnTime;
        
        public Entity Prefab;
        public float3 SpawnPosition;
        public double SpawnDelay;

        public EntitySpawner(
            Entity prefab,
            float3 spawnPosition,
            double spawnDelay
            )
        {
            Prefab = prefab;
            SpawnPosition = spawnPosition;
            SpawnDelay = spawnDelay;
            
            NextSpawnTime = 0;
        }
    }
}