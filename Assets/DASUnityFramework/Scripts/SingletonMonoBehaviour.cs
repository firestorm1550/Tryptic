using System;
using UnityEngine;

namespace DASUnityFramework.Scripts
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (!_instance)
                {
                    GameObject gameObject = new GameObject(nameof(T) + " Singleton Instance");
                    _instance = gameObject.AddComponent<T>();
                    DontDestroyOnLoad(gameObject);
                }
                
                return _instance; 
            }
        }

        private static T _instance;
    }
}