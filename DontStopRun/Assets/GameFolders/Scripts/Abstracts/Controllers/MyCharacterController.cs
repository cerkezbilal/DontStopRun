using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopRun.Abstract.Controllers
{
    public abstract class MyCharacterController: MonoBehaviour
    {
        [SerializeField] float _moveBoundary = 4.5f;
        [SerializeField] protected float _moveSpeed = 7f;

        public float MoveSpeed => _moveSpeed;

        public float MoveBoundary => _moveBoundary;
    }
}

