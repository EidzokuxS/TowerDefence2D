using SpaceShooter;
using UnityEngine;

namespace TowerDefence
{
    //[RequireComponent(typeof(CircleArea))]
    public class EntitySpawner : Spawner
    {
        #region Properties

        [SerializeField] private Entity[] _entityPrefabs;

        #endregion

        #region Private API
        protected override GameObject GenerateSpawnedEntity()
        {
            int index = Random.Range(0, _entityPrefabs.Length);
            return Instantiate(_entityPrefabs[index].gameObject);
        }

        #endregion
    }

}

