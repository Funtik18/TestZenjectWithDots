using Unity.Entities;

namespace Game.ECS
{
    public sealed class EntitySpawnerBaker : Baker< EntitySpawnerAuthoring >
    {
        public override void Bake( EntitySpawnerAuthoring authoring )
        {
            var entity = GetEntity( TransformUsageFlags.None );
            
            AddComponent( entity, new EntitySpawner(
                GetEntity( authoring.Prefab, TransformUsageFlags.Dynamic ),
                authoring.transform.position,
                authoring.SpawnDelay
                ));
        }
    }
}