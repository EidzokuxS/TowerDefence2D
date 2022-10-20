using UnityEngine;

namespace TowerDefence
{
    //[RequireComponent(typeof(CircleArea))]
    public class EnemySpawner : Spawner
    {
        #region Properties

        [SerializeField] private Enemy _enemyPrefabs;
        [SerializeField] private Path _path;
        [SerializeField] private EnemyAsset[] _enemySettings;

        #endregion

        #region Private API
        protected override GameObject GenerateSpawnedEntity()
        {
            var enemy = Instantiate(_enemyPrefabs);
            enemy.UseAssetSettings(_enemySettings[Random.Range(0, _enemySettings.Length)]);

            enemy.GetComponent<TD_PatrolController>().SetPath(_path);

            return enemy.gameObject;
        }

        #endregion
    }

}

