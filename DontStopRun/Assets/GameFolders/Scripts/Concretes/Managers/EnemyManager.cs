using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Utilities;
using DontStopRun.Controllers;
using UnityEngine;

namespace DontStopRun.Managers
{
    public class EnemyManager : SingletonMonoBehaviorObject<EnemyManager>
    {
        [SerializeField] EnemyController[] _enemyPrefabs;

        //Bir liste türüdür ama farkı sırası yoktur. Queue : Kuyruk demektir
        Queue<EnemyController> _enemies = new Queue<EnemyController>();

        private void Awake()
        {
            SingletonThisObject(this);
        }

        private void Start()
        {
            InitializePool();
        }

        //Pool Sistemi oluştur demek Bu bir kere çalışcaz oyun ilk açıldığında
        void InitializePool()
        {
            //sayıyı arttırabilirsiniz kurşun olsa daha fazla yapardık ama bizim

            for (int i = 0; i < 10; i++)
            {
                //Enemy objesinden 10 tane oluştur
                EnemyController newEnemy = Instantiate(_enemyPrefabs[Random.Range(0,_enemyPrefabs.Length)]);//Örnek

                //Oluşanları gizle ihtiyaç olunca çağırcaz
                newEnemy.gameObject.SetActive(false);

                //Sahnede birikmesin diye EnemyManager altında topla
                newEnemy.transform.parent = this.transform;

                //bunları kuyruğumuza(listemize) ekliyoruz)
                _enemies.Enqueue(newEnemy);

            }
           
        }
        //Dışarıdan gelen düşmanı Pool havuzuna eklicek
        public void SetPool(EnemyController enemyController)
        {
            //Düzen. Manager altına koy
            enemyController.transform.parent = this.transform;

            //Geri gönderileni tekrar gizle
            enemyController.gameObject.SetActive(false);
            //Parametre olarak geleni kuyruğa ekle
            _enemies.Enqueue(enemyController);
        }

        //Enemy yi havuzdan çıkar yani kullan.
        public EnemyController GetPool()
        {
            //Böyle bir nesne yoksa
            if(_enemies.Count == 0)
            {
                //Bu fonksiyon ile oluştur
                InitializePool();
            }

            //Böyle bir nesne varsa Sıradakini dön demek
            return _enemies.Dequeue();
        }
    }//class
}

