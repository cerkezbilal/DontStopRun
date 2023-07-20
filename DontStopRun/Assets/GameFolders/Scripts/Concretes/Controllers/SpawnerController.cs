using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DontStopRun.Controllers
{
    public class SpawnerController : MonoBehaviour
    {
        //Bunu ileride değiştircez şuan deneme amaçlı
        [SerializeField] EnemyController _enemyPrefab;
        [Range(0.1f,5f)]
        [SerializeField] float _min = 0.1f;
        [Range(6f, 15f)]
        [SerializeField] float _max = 15f;


        float _maxSpawnTime;

        float _currentSpanwTime = 0f;

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
            
        }

        void Spawn()
        {
            //düşman Oluşturma işlemi.
           EnemyController newEnemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
            newEnemy.transform.parent = this.transform;
            _currentSpanwTime = 0f;
            GetRondomMaxTime();//Her düşman oluştuktan sonra.
        }

        private void GetRondomMaxTime()
        {
            _maxSpawnTime = Random.Range(_min, _max);
        }

    }//class
}
