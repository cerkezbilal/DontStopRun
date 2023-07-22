using System.Collections;
using System.Collections.Generic;
using DontStopRun.Managers;
using UnityEngine;

namespace DontStopRun.Uis
{
    public class MenuPanel : MonoBehaviour
    {

        public void SelectAndStartButton(int index)
        {
            GameManager.Instace.DifficultyIndex = index;
            GameManager.Instace.LoadScene("Game");
        }

        public void ExitButton()
        {
            GameManager.Instace.ExitGame();
        }





    }//class
}

