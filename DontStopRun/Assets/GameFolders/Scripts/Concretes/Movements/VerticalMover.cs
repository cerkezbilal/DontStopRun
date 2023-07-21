using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Controllers;
using DontStopRun.Abstract.Movements;
using DontStopRun.Controllers;
using UnityEngine;

namespace DontStopRun.Movements
{
    public class VerticalMover : IMover
    {
        IEntityController _enemyController;
        float _moveSpeed;

        public VerticalMover(IEntityController entityController)
        {
            _enemyController = entityController;
            _moveSpeed = _enemyController.MoveSpeed;
        }

        public void FixedTick(float vertical = 1)
        {
            _enemyController.transform.Translate(Vector3.back * vertical * Time.deltaTime * _moveSpeed);
        }
    }
}

