using System.Collections;
using System.Collections.Generic;
using DontStopRun.Controllers;
using UnityEngine;

namespace DontStopRun.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level Difficulty", menuName = "Create Difficulty/Create New", order =1)]
    public class LevelDifficultyData : ScriptableObject
    {
        [SerializeField] FloorController _floorPrefabs;
        [SerializeField] GameObject _spawnersPrefab;
        [SerializeField] Material _skyboxMaterial;
        [SerializeField] float _moveSpeed = 7f;
        [SerializeField] float _addDelayTime = 50f;

        public FloorController FloorPrefab => _floorPrefabs;
        public GameObject SpawnersPrefab => _spawnersPrefab;
        public Material SkyboxMaterial => _skyboxMaterial;
        public float MoveSpeed => _moveSpeed;
        public float AddDelayTime => _addDelayTime;







    }
}

