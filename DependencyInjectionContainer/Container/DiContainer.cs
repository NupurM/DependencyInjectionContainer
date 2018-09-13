using System;
using System.Collections.Generic;
using System.Reflection;

namespace DependencyInjectionContainer.Container
{
    public class DiContainer
    {
        private readonly Dictionary<Type, Type> _types = new Dictionary<Type, Type>();

        public void Register<TInterface, TClass>()
        {
            if (_types.ContainsKey(typeof(TInterface)))
            {
                throw new Exception("Interface type already registered");
            }
            _types.Add(typeof(TInterface), typeof(TClass));
        }

        public TInterface Resolve<TInterface>()
        {
            // Resolve returns the implementation
            // Someone else deals with the embedded dependencies
            // It receives and object which it casts into the type ie. interface and returns it
            return (TInterface)GetImplementation(typeof(TInterface));
        }

        // Take the actual type as the input to help with recursive function calls
        private object GetImplementation(Type interfaceType)
        {
            // Check if the key exists in the dictionary
            if (!_types.ContainsKey(interfaceType))
            {
                throw new Exception("Interface type does not exist");
            }

            // Get the value from the dictionary
            _types.TryGetValue(interfaceType, out Type implementation);

            // Identify the dependencies of this class by getting the constructor information
            ConstructorInfo constructorInfo = implementation.GetConstructors()[0];
            var constructorParams = constructorInfo.GetParameters();

            // List of implementations needed to call the constructor
            List<object> constructorParamImplementations = new List<object>();

            // For the constructor
            // Get the list of all classes it depends on
            foreach (var param in constructorParams)
            {
                //  Get the dependent implementations recursively
                constructorParamImplementations.Add(GetImplementation(param.ParameterType));
            }

            // Call or invoke the constructor with its parameters
            // This is the 0th constructor that we picked
            // The parameters are the dependent class implementations that we retrieved
            return constructorInfo.Invoke(constructorParamImplementations.ToArray());
        }
    }
}