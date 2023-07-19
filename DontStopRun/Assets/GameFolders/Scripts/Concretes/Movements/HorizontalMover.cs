using System.Collections;
using System.Collections.Generic;
using DontStopRun.Controllers;
using UnityEngine;

namespace DontStopRun.Movements
{
    public class HorizontalMover 
    {

        PlayerController _playerController;

        public HorizontalMover(PlayerController playerController)
        {
            _playerController = playerController;
        }

        #region Sağ Sol hareket işlemleri
        public void TickFixed(float horizontal, float moveSpeed)
        {
            //Sağa sola gidiş yoksa bişey yapma
            if (horizontal == 0) return;


            //Eğer sağa sola gidiş varsa gönderdiğimiz horizontala göre(+ sağ - sol demek karakteri translate yani hareket ettir.

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * moveSpeed);

        }

        #endregion




    }//class
}

