using SpaceShooter;
using UnityEngine;

namespace TowerDefence
{
    public class TDPlayer : Player
    {
        #region Properties

        [SerializeField] private int _goldAmount;

        #endregion

        #region Public API


        public void ChangeGold(int amount)
        {
            if (_goldAmount + amount < 0)
                return;

            _goldAmount += amount;
        }

        #endregion
    }

}
