using System.Collections;
using System.Collections.Generic;
using DontStopRun.Enums;
using DontStopRun.Managers;
using UnityEngine;

namespace DontStopRun.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
      
        
        [Range(0.1f,5f)]
        [SerializeField] float _min = 0.1f;
        [Range(6f, 15f)]
        [SerializeField] float _max = 15f;


        float _maxSpawnTime;

        float _currentSpanwTime = 0f;

        float _index = 0;
        float _maxAddEnemyTime;

        public bool CanIncrease => _index < EnemyManager.Instace.Count;




        private void OnEnable()
        {

            GetRondomMaxTime();//Oyun ilk çalıştığında
        }

        //Belli bir sürede oluşması lazım

        private void Update()
        {
            _currentSpanwTime += Time.deltaTime;

            if(_currentSpanwTime > _maxSpawnTime)
            {
                Spawn();
                
            }

            if (!CanIncrease) return;

            if (_maxAddEnemyTime < Time.time)
            {
                _maxAddEnemyTime = Time.time + EnemyManager.Instace.AddDelayTime;

                IncreaseIndex();

            }
            
        }

        private void IncreaseIndex()
        {
            if(CanIncrease)
            {
                //index küçükse Count dan index artsın
                _index++;
            }
        }

        void Spawn()
        {
           
            //düşman Oluşturma işlemi.
            EnemyController newEnemy = EnemyManager.Instace.GetPool((EnemyEnum)Random.Range(0,_index));
            newEnemy.transform.parent = this.transform;
            newEnemy.transform.position = this.transform.position;
            newEnemy.gameObject.SetActive(true);
            _currentSpanwTime = 0f;
            GetRondomMaxTime();//Her düşman oluştuktan sonra.
        }

        private void GetRondomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }

    }//class
}

