using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Utilities;
using UnityEngine;

namespace DontStopRun.Managers
{
    public class GameManager : SingletonMonoBehaviorObject<GameManager>
    {
        void Awake()
        {
            SingletonThisObject(this);
        }


        public void StopGame()
        {
            //Oyunu tamamen durdurur
            Time.timeScale = 0f;
        }



    }//class

   

}
