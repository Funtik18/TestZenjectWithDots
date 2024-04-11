using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS
{
    [ BurstCompile ]
    public partial struct MovableSystem : ISystem
    {
        [ BurstCompile ]
        public void OnUpdate( ref SystemState state )
        {
            EntityManager entityManager = state.EntityManager;
            NativeArray< Entity > entities = entityManager.GetAllEntities( Allocator.Temp );
            
            foreach ( var entity in entities )
            {
                if ( !entityManager.HasComponent< MovableComponentData >( entity ) ) continue;
            
                MovableComponentData movable = entityManager.GetComponentData< MovableComponentData >( entity );
                LocalTransform localTransform = entityManager.GetComponentData< LocalTransform >( entity );
            
                float3 velocity = movable.MoveDirection * SystemAPI.Time.DeltaTime * movable.MoveSpeed;
                localTransform.Position += velocity;
            
                if ( movable.MoveSpeed > 0 )
                {
                    movable.MoveSpeed -= SystemAPI.Time.DeltaTime;
                }
                else
                {
                    movable.MoveSpeed = 0;
                }
                
                entityManager.SetComponentData( entity, localTransform );
                entityManager.SetComponentData( entity, movable );
            }
        }
    }
}