using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Controllers;
using DontStopRun.Abstract.Movements;
using DontStopRun.Enums;
using DontStopRun.Managers;
using DontStopRun.Movements;
using UnityEngine;

namespace DontStopRun.Controllers
{
    public class EnemyController : MyCharacterController, IEntityController
    {
        [SerializeField] EnemyEnum _enemyEnum;//Hangi enemy
        [SerializeField] float _maxLifeTime = 10f;

        float _currentLifeTime = 0f;

        IMover _mover;

        public EnemyEnum EnemyType => _enemyEnum;


        private void Awake()
        {
            _mover = new VerticalMover(this);
        }

        private void FixedUpdate()
        {
            _mover.FixedTick(1);
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if(_currentLifeTime > _maxLifeTime)
            {
                _currentLifeTime = 0f;
                KillYourSelf();
            }
        }

        void KillYourSelf()
        {
            EnemyManager.Instace.SetPool(this);
        }

        public void SetMoveSpeed(float moveSpeed)
        {
            if (moveSpeed < _moveSpeed) return;
            _moveSpeed = moveSpeed;
        }


    }//class
}

