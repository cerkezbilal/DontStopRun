using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DontStopRun.Uis
{
    public class TimeCounter : MonoBehaviour
    {
        TMP_Text _text;
        float _currentTime;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;
            _text.text = _currentTime.ToString("0"); //Ondalıklı gitmesin
        }





    }//class
}

