using System.Collections;
using System.Collections.Generic;
using DontStopRun.Managers;
using UnityEngine;

namespace DontStopRun.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameOverPanel _gameOverPanel;

        private void Awake()
        {
            //ilk oyun başlayınca kapalı olsun
            _gameOverPanel.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.Instace.OnGameStop += HandleOnGameStop;
        }

        private void OnDisable()
        {
            GameManager.Instace.OnGameStop -= HandleOnGameStop;
        }

        void HandleOnGameStop()
        {
            _gameOverPanel.gameObject.SetActive(true);
        }







    }//class
}

