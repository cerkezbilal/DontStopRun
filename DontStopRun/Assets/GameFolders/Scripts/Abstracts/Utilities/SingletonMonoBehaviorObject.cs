using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopRun.Abstract.Utilities
{
    public abstract class SingletonMonoBehaviorObject<T> : MonoBehaviour where T: Component
    {
        //bu şablon sabittir 
        public static T Instace { get; private set; }

        protected void SingletonThisObject(T entity)
        {
            if(Instace == null)
            {
                Instace = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }


    }//class
}

