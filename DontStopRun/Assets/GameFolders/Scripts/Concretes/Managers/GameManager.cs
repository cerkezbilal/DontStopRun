using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void LoadScene(string sceneName)
        {

            StartCoroutine(LoadSceneAsync(sceneName));
        }

        IEnumerator LoadSceneAsync(string sceneName)
        {
            Time.timeScale = 1f;
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

        public void ExitGame()
        {
            Debug.Log("Çıkış yapıldı");
            Application.Quit();
        }



    }//class

   

}
