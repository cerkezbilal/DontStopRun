using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopRun.Controllers
{
    public class FloorController : MonoBehaviour
    {

        Material _material;
        [Range(0.2f,2f)]
        [SerializeField] float _moveSpeed = 5f;

        private void Awake()
        {
            //Neden Childeren çünkü Floor1 da Mesh yok onun içinde ki Plane da var
            _material = GetComponentInChildren<MeshRenderer>().material;
        }

        private void FixedUpdate()
        {
            //Offset değeri - ye doğru gitmeli y de.
            _material.mainTextureOffset += Vector2.down * Time.deltaTime * _moveSpeed;
        }





    }//class
}

