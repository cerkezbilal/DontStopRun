using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Movements;
using DontStopRun.Controllers;
using UnityEngine;

namespace DontStopRun.Movements
{
    public class VerticalMover : IMover
    {
        EnemyController _enemyController;
        float _moveSpeed;

        public VerticalMover(EnemyController enemyController)
        {
            _enemyController = enemyController;
            _moveSpeed = _enemyController.MoveSpeed;
        }

        public void FixedTick(float vertical = 1)
        {
            _enemyController.transform.Translate(Vector3.back * vertical * Time.deltaTime * _moveSpeed);
        }
    }
}

