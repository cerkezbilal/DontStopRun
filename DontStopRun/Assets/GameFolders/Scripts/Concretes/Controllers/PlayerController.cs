using System.Collections;
using System.Collections.Generic;
using DontStopRun.Movements;
using UnityEngine;

namespace DontStopRun.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float _horizontalDirection = 0f;
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;
        [SerializeField] bool _isJump;


        HorizontalMover _horizontalMover;
        JumpWithRigidbody _jump;


        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);
        }

        
        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontalDirection, _moveSpeed);

            if (_isJump)
            {
                _jump.TickFixed(_jumpForce);
                
            }

            _isJump = false;
        }



    }//class
}

