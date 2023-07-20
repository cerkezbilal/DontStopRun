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

        public void LoadScene()
        {
            //Load işlemleri olacak
            Debug.Log("Yeni Ekran");
        }

        public void ExitGame()
        {
            Debug.Log("Çıkış yapıldı");
            Application.Quit();
        }



    }//class

   

}
