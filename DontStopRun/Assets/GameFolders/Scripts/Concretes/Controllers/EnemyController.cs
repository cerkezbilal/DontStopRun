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

        public float MoveSpeed => _moveSpeed;

        private void Awake()
        {
            _mover = new VerticalMover(this);
        }

        private void FixedUpdate()
        {
            _mover.FixedTick();
        }


    }//class
}

