using System;
using System.Reflection;

namespace Experia.Framework.Generics
{
    /// <summary>
    /// Simply add this example line of code to generate a Singleton without all the other hassle!
    /// public static FooBarClass Instance { get { return Singleton[FooBarClass].Instance; } }
    /// The [] are left and right arrows respectively!
    /// </summary>
    /// <typeparam name="T">What class type you want to make a singleton</typeparam>
    public static class Singleton<T> where T : class
    {
        private static volatile T m_Instance;
        private static object m_Lock = new object();

        static Singleton() { /*No Body Needed*/ }

        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    lock (m_Lock)
                    {
                        if (m_Instance == null)
                        {
                            ConstructorInfo constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);

                            if (constructor == null || constructor.IsAssembly)
                            {
                                throw new InvalidOperationException("A private or protected constructor is needed for " + typeof(T).Name + " to be a singleton.");
                            }
                            //Invoke the constructor that was given to us
                            m_Instance = (T)constructor.Invoke(null);
                        }
                    }
                }

                return m_Instance;
            }
        }
    }
}
