using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Movements;
using DontStopRun.Controllers;
using UnityEngine;

namespace DontStopRun.Movements
{
    public class JumpWithRigidbody : IJump
    {
        Rigidbody _rigidbody;

        public bool CanJump => _rigidbody.velocity.y != 0;



        public JumpWithRigidbody(PlayerController playerController)
        {

            _rigidbody = playerController.GetComponent<Rigidbody>();

        }

        #region Zıplama işlemi

        public void FixedTick(float jumpForce)
        {
            //Hava da demektir.Hata alırsak düzelticez(!)
            if (CanJump) return;

            //Hava da değilse
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector3.up * Time.deltaTime * jumpForce);
        }

        #endregion




    }//class
}

