using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Inputs;
using DontStopRun.Inputs;
using DontStopRun.Managers;
using DontStopRun.Movements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DontStopRun.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] float _jumpForce = 300f;

        //Bunu dışardan alalım ki ileride alanımızı genişletirsek yönetilebilir olsun

        [SerializeField] float _moveBoundary = 4.5f;
       


        HorizontalMover _horizontalMover;
        JumpWithRigidbody _jump;

        IInputReader _input;//Interface den değişken türettik

        float _horizontal;
        bool _isJump;

        bool _isDead = false;

        public float MoveSpeed => _moveSpeed;

        public float MoveBoundary => _moveBoundary;


        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
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
            _horizontalMover.TickFixed(_horizontal);

            if (_isJump)
            {
                _jump.TickFixed(_jumpForce);

            }

            _isJump = false;


        }

        private void OnTriggerEnter(Collider other)
        {
            EnemyController enemyController = other.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                GameManager.Instace.StopGame();
                _isDead = true;
            }
        }



    }//class
}

