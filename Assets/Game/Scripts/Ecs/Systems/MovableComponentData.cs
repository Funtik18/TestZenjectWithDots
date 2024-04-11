using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS
{
    public struct MovableComponentData : IComponentData
    {
        public float3 MoveDirection;
        public float MoveSpeed;

        public MovableComponentData(
            float3 moveDirection,
            float moveSpeed
            )
        {
            MoveDirection = moveDirection;
            MoveSpeed = moveSpeed;
        }
    }
}