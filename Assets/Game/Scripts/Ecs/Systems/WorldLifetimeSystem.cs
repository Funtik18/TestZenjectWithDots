using Unity.Entities;
using UnityEngine;

namespace Game.ECS
{
    public partial class WorldLifetimeSystem : SystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop( World );
            Enabled = false;
            
            Debug.Log( "[World] World appended to player loop" );
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if ( World.DefaultGameObjectInjectionWorld == World )
            {
                World.DefaultGameObjectInjectionWorld = null;
            }
            
            ScriptBehaviourUpdateOrder.RemoveWorldFromCurrentPlayerLoop( World );
            
            Debug.Log( "[World] World disposed" );
        }

        protected override void OnUpdate() { }
    }
}