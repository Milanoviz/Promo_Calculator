using System;
using System.Collections.Generic;

namespace Modules.DI.Scripts
{
    public class DiContainer : IDiContainer
    {
        private readonly Dictionary<Type, object> _instances = new();
        
        public void Bind<T>(T implementation) where T : class
        {
            _instances[typeof(T)] = implementation;
        }

        public T Resolve<T>() where T : class
        {
            _instances.TryGetValue(typeof(T), out var service);
            return service as T;
        }
    }
}