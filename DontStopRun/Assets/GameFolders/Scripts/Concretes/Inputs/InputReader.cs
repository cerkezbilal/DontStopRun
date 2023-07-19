using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DontStopRun.Inputs
{
    public class InputReader : IInputReader
    {

        PlayerInput _playerInput;
        public float Horizontal { get; private set; }


        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;

            _playerInput.currentActionMap.actions[0].performed += OnHorizontalMove;


            void OnHorizontalMove(InputAction.CallbackContext context)
            {
                //Aksiyondan gelen değeri horizontala atıcak
                Horizontal = context.ReadValue<float>();
            }

        }




    }//class
}

