using System.Collections;
using System.Collections.Generic;
using DontStopRun.Movements;
using UnityEngine;

namespace DontStopRun.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        VerticalMover _mover;
        [SerializeField] float _moveSpeed = 7f;
        [SerializeField] float _maxLifeTime = 10f;

        float _currentLifeTime = 0f;

        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _mover = new VerticalMover(this);
        }

        private void FixedUpdate()
        {
            _mover.FixedTick();
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
            Destroy(this.gameObject);
        }


    }//class
}

