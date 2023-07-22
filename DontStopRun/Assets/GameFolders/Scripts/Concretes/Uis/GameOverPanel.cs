using System.Collections;
using System.Collections.Generic;
using DontStopRun.Managers;
using UnityEngine;

namespace DontStopRun.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
       
        public void YesButton()
        {
            GameManager.Instace.LoadScene("Game");
        }

        public void NoButton()
        {
            GameManager.Instace.LoadScene("Menu");
        }



    }//class
}

