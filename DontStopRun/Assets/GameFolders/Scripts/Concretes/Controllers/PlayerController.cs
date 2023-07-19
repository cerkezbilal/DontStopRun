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
        HorizontalMover _horizontalMover;

        private void Awake()
        {
            _horizontalMover = new HorizontalMover(this);
        }

        
        private void FixedUpdate()
        {
            _horizontalMover.TickFixed(_horizontalDirection, _moveSpeed);
        }



    }//class
}

