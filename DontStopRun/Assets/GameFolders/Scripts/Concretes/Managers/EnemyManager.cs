using System.Collections;
using System.Collections.Generic;
using DontStopRun.Abstract.Utilities;
using DontStopRun.Controllers;
using DontStopRun.Enums;
using UnityEngine;

namespace DontStopRun.Managers
{
    public class EnemyManager : SingletonMonoBehaviorObject<EnemyManager>
    {
        [SerializeField] EnemyController[] _enemyPrefabs;

        //Bir liste türüdür ama farkı sırası yoktur. Queue : Kuyruk demektir
        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();

        

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
            for (int i = 0; i < _enemyPrefabs.Length; i++)
            {
                Queue<EnemyController> enemyController = new Queue<EnemyController>();
                //sayıyı arttırabilirsiniz kurşun olsa daha fazla yapardık ama bizim

                for (int j = 0; j < 10; j++)
                {

                    //Enemy objesinden 10 tane oluştur
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[i]);//Örnek

                    //Oluşanları gizle ihtiyaç olunca çağırcaz
                    newEnemy.gameObject.SetActive(false);

                    //Sahnede birikmesin diye EnemyManager altında topla
                    newEnemy.transform.parent = this.transform;

                    enemyController.Enqueue(newEnemy);

                    
                }
                //Yani burda EnemyEnum un i si 0 1 2 
                _enemies.Add((EnemyEnum)i, enemyController);

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

