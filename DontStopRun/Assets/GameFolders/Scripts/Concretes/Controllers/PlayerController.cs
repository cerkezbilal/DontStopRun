using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Controllers;
using DontStopRun.Abstract.Inputs;
using DontStopRun.Abstract.Movements;
using DontStopRun.Inputs;
using DontStopRun.Managers;
using DontStopRun.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DontStopRun.Controllers
{
    public class PlayerController : MyCharacterController, IEntityController
    {
        
     
        [SerializeField] float _jumpForce = 300f;

        IMover _mover;
        IJump _jump;

        IInputReader _input;//Interface den değişken türettik

        float _horizontal;
        bool _isJump;

        bool _isDead = false;

       


        private void Awake()
        {
            _mover = new HorizontalMover(this);
            _jump = new JumpWithRigidbody(this);

            //o değişkeni InputRerader a instace ettik 
            _input = new InputReader(GetComponent<PlayerInput>());
        }

        private void Update()
        {
            if (_isDead) return;
            _horizontal = _input.Horizontal;
            
            if (_input.IsJump)
            {
                _isJump = true;
            }
            
        }


        private void FixedUpdate()
        {
            _mover.FixedTick(_horizontal);

            if (_isJump)
            {
                _jump.FixedTick(_jumpForce);

            }

            _isJump = false;


        }

        private void OnTriggerEnter(Collider other)
        {
            IEntityController entityController = other.GetComponent<IEntityController>();
            if (entityController != null)
            {
                GameManager.Instace.StopGame();
                _isDead = true;
            }
        }

       



    }//class
}

