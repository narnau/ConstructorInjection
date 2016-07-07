using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InversionOfControl.Business.Interfaces;
using Spring.Objects.Factory;

namespace InversionOfControl
{
    public class BasicContainer
    {
        private readonly IDictionary<Type, Type> register;

        public BasicContainer()
        {
            this.register = new Dictionary<Type, Type>();
        }

        public void Register<TInterface, TClass>()
        {
            register.Add(typeof(TInterface), typeof(TClass));
        }

        public T Create<T>()
        {
            return (T)Instantiate<T>(typeof(T));
        }

        private T Instantiate<T>(Type type)
        {
            IList<Type> dependencies = new List<Type>();

            foreach (var constructorInfo in this.register[type].GetConstructors())
            {
                for (int i = 0; i < constructorInfo.GetParameters().Length; i++)
                {
                    dependencies.Add(constructorInfo.GetParameters()[i].ParameterType);
                }
            }

            if (dependencies.Count > 0)
            {
                object[] instantiatedDependencies = InstantiateDependencies(dependencies);
                return (T)Activator.CreateInstance(this.register[type], instantiatedDependencies);
            }
            
            return (T)Activator.CreateInstance(this.register[type]);
        }

        private object[] InstantiateDependencies(IList<Type> dependencies)
        {
            object[] dep = new object[dependencies.Count];
            for (int i = 0; i < dependencies.Count; i++)
            {
                MethodInfo method = typeof(BasicContainer).GetMethod("Create");
                MethodInfo generic = method.MakeGenericMethod(dependencies[i]);
                dep[i] = generic.Invoke(this, null);
            }
            return dep;
        }
    }
}
