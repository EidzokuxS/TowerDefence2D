using SpaceShooter;
using UnityEngine;

namespace TowerDefence
{
    //[RequireComponent(typeof(CircleArea))]
    public abstract class Spawner : MonoBehaviour
    {
        #region Properties

        public enum SpawnMode
        {
            Start,
            Loop
        }


        [SerializeField] private CircleArea _circleArea;

        [SerializeField] private SpawnMode _spawnMode;

        [SerializeField] private int _spawnCount;

        [SerializeField] private float _spawnTime;

        private float _timer;

        #endregion

        #region Unity Events

        private void Start()
        {
            if (_spawnMode == SpawnMode.Start)
            {
                SpawnEntities();
            }

        }

        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }

            if (_spawnMode == SpawnMode.Loop && _timer <= 0)
            {
                SpawnEntities();

                _timer = _spawnTime;
            }
        }
        #endregion

        #region Private API
        protected abstract GameObject GenerateSpawnedEntity();

        private void SpawnEntities()
        {
            for (int i = 0; i < _spawnCount; i++)
            {
                var entities = GenerateSpawnedEntity();
                entities.transform.position = _circleArea.GetRandomInsideZone();
            }
        }

        #endregion
    }

}

