using System.Collections;
using System.Collections.Generic;
using DontStopRun.Managers;
using UnityEngine;

namespace DontStopRun.Uis
{
    public class MenuPanel : MonoBehaviour
    {

        public void StartButton()
        {
            GameManager.Instace.LoadScene("Game");
        }

        public void ExitButton()
        {
            GameManager.Instace.ExitGame();
        }





    }//class
}
