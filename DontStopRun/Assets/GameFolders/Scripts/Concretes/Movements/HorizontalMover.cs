using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Controllers;
using DontStopRun.Abstract.Movements;
using DontStopRun.Controllers;
using UnityEngine;

namespace DontStopRun.Movements
{
    public class HorizontalMover : IMover 
    {

        IEntityController _playerController;
        

        public HorizontalMover(IEntityController entityController)
        {
            _playerController = entityController;
            
        }

        #region Sağ Sol hareket işlemleri
        public void FixedTick(float horizontal)
        {
            //Sağa sola gidiş yoksa bişey yapma
            if (horizontal == 0) return;


            //Eğer sağa sola gidiş varsa gönderdiğimiz horizontala göre(+ sağ - sol demek karakteri translate yani hareket ettir.

            _playerController.transform.Translate(Vector3.right * horizontal * Time.deltaTime * _playerController.MoveSpeed);

            //Clamps girilen birinci parametre, ikincisi min değer üçüncüsü max değer. Bu fonksiyon girilen birinci değerin min ve max değer aralığında olup olmadığını kontrol eder.
            float xBoundary = Mathf.Clamp(_playerController.transform.position.x, -_playerController.MoveBoundary, _playerController.MoveBoundary);

            _playerController.transform.position = new Vector3(xBoundary, _playerController.transform.position.y, _playerController.transform.position.z);
            
        }

        #endregion




    }//class
}

