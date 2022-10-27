using SpaceShooter;
using System;
using UnityEngine;

namespace TowerDefence
{
    public class TDPlayer : Player
    {
        #region Properties

        [SerializeField] private int _goldAmount;

        public static new TDPlayer Instance => Player.Instance as TDPlayer;

        #region Events

        private static event Action<int> OnGoldUpdate;
        public static void SubscribeGoldUpdate(Action<int> action)
        {
            OnGoldUpdate += action;
            action(Instance._goldAmount);
        }

        private static event Action<int> OnHealthUpdate;
        public static void SubscribeHealthUpdate(Action<int> action)
        {
            OnHealthUpdate += action;
            action(Instance.CurrentLives);
        }

        #endregion


        #endregion

        #region Unity Events

        #endregion

        #region Public API


        public void ChangeGold(int amount)
        {
            if (_goldAmount + amount < 0)
                return;

            _goldAmount += amount;
            OnGoldUpdate(_goldAmount);
        }
        public void ReduceHealth(int amount)
        {
            TakeDamage(amount);
            OnHealthUpdate(CurrentLives);
        }

        [SerializeField] private Tower _towerPrefab;
        public void TryBuildTower(TowerAsset asset, Transform buildPosition)
        {
            ChangeGold(-asset._goldCost);
            var tower = Instantiate(_towerPrefab, buildPosition.position, Quaternion.identity);
            tower.GetComponentInChildren<SpriteRenderer>().sprite = asset._towerSprite;
            Destroy(buildPosition.gameObject);

        }

    }

    #endregion
}


