namespace Modules.DI.Scripts
{
    public interface IDiContainer
    {
        void Bind<T>(T implementation) where T : class;
        T Resolve<T>() where T : class;
    }
}