using System.Collections;
using System.Collections.Generic;
using DontStopRun.Managers;
using DontStopRun.ScriptableObjects;
using UnityEngine;

namespace DontStopRun.Controllers
{
    public class LevelInitializerController : MonoBehaviour
    {
        LevelDifficultyData _levelDifficultyData;

        private void Awake()
        {
            _levelDifficultyData = GameManager.Instace.levelDifficultyData;
        }

        private void Start()
        {
            RenderSettings.skybox = _levelDifficultyData.SkyboxMaterial;
            Instantiate(_levelDifficultyData.FloorPrefab);
            Instantiate(_levelDifficultyData.SpawnersPrefab);
        }
    }
}

