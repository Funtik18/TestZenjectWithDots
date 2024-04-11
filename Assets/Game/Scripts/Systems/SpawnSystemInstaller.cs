using Zenject;

namespace Game.Systems.SpawnSystem
{
    public sealed class SpawnSystemInstaller : ScriptableObjectInstaller< SpawnSystemInstaller >
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo< SpawnSystem >().AsSingle();
        }
    }
}