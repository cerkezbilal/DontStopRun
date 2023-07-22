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
        [SerializeField] float _addDelayTime = 50f;

        //Bir liste türüdür ama farkı sırası yoktur. Queue : Kuyruk demektir
        Dictionary<EnemyEnum, Queue<EnemyController>> _enemies = new Dictionary<EnemyEnum, Queue<EnemyController>>();

        public float AddDelayTime => _addDelayTime;

        public float Count => _enemyPrefabs.Length;

        float _moveSpeed;

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

            //bu bize starndart Height gibi verileri dönecek
            Queue<EnemyController> enemyControllers = _enemies[enemyController.EnemyType];

            //Oluşturduğu Kuyruğa parametre olarak gelen EnemyController ekledim
            enemyControllers.Enqueue(enemyController);
            
        }

        //Enemy yi havuzdan çıkar yani kullan.
        public EnemyController GetPool(EnemyEnum enemyType)
        {
            
            Queue<EnemyController> enemyControllers = _enemies[enemyType];

            //Eğer bu türde enum yoksa oluştur
            if (enemyControllers.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    //Yedekte kalsın biri her ihtimale karşı.
                    EnemyController newEnemy = Instantiate(_enemyPrefabs[(int)enemyType]);
                    enemyControllers.Enqueue(newEnemy);

                }
                
            }
            EnemyController enemyController = enemyControllers.Dequeue();
            enemyController.SetMoveSpeed(_moveSpeed);
            return enemyController;

        }

        public void SetMoveSpeed(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }
    }//class
}

