using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Utilities;
using DontStopRun.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DontStopRun.Managers
{
    public class GameManager : SingletonMonoBehaviorObject<GameManager>
    {


        [SerializeField] LevelDifficultyData[] _levelDifficultyDatas;

        public LevelDifficultyData levelDifficultyData => _levelDifficultyDatas[DifficultyIndex];//Şimdilik 0 ı alıyoruz easy hazır çünkü

        int _difficultyIndex;

        public event System.Action OnGameStop;

        public int DifficultyIndex {

            get => _difficultyIndex;
            set
            {
                //Yani indexte hata olursa direk menüye dön
                if(_difficultyIndex < 0 || _difficultyIndex > _levelDifficultyDatas.Length)
                {
                    LoadSceneAsync("Menu");
                }
                else
                {
                    _difficultyIndex = value;
                }
            }
        }


        void Awake()
        {
            SingletonThisObject(this);
        }


        public void StopGame()
        {
            //Oyunu tamamen durdurur
            Time.timeScale = 0f;

            //Oyun durunca bu eventi çalıştır demek
            OnGameStop?.Invoke();
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
