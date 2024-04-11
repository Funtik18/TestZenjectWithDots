using Unity.Entities;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class WorldInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo< World >()
                .FromMethod( CreateWorld )
                .AsSingle()
                .NonLazy();

            Debug.Log( "[World] World created" );
        }

        private World CreateWorld( InjectContext injectContext )
        {
            World world = new World( "GameWorld" );
            World.DefaultGameObjectInjectionWorld = world;

            DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups( world, DefaultWorldInitialization.GetAllSystems( WorldSystemFilterFlags.Default ) );

            var container = injectContext.Container;
            foreach ( var system in world.Systems )
            {
                container.Inject( system );
            }

            return world;
        }
    }
}