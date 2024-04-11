using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS
{
    [ BurstCompile ]
    [ UpdateInGroup( typeof( InitializationSystemGroup )) ]
    public partial struct EntitySpawnerSystem : ISystem
    {
        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            EntityCommandBuffer ecb = new EntityCommandBuffer( Allocator.Temp );
            
            foreach ( RefRW< EntitySpawner > spawner in SystemAPI.Query< RefRW< EntitySpawner > >() )
            {
                SpawnProcess( ref state, spawner, ecb );
            }
            
            ecb.Playback( state.EntityManager );
            ecb.Dispose();
        }

        private void SpawnProcess( ref SystemState state, RefRW< EntitySpawner > spawner, EntityCommandBuffer ecb )
        {
            if ( spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime )
            {
                spawner.ValueRW.NextSpawnTime = SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnDelay;
                
                Entity newEntity = ecb.Instantiate( spawner.ValueRO.Prefab );
                ecb.AddComponent( newEntity, new MovableComponentData( new float3( 0, 1, 0 ), 10f ) );
                ecb.SetComponent( newEntity, LocalTransform.FromPosition( spawner.ValueRO.SpawnPosition ) );
            }
        }
    }
}