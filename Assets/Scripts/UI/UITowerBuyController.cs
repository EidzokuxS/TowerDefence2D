using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefence
{
    public class UITowerBuyController : MonoBehaviour
    {

        #region Properties

        [SerializeField] private TowerAsset _towerAsset;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Transform _buildPosition;
        public Transform BuildPosition { set { _buildPosition = value; } }

        #endregion

        #region Unity Events

        private void Start()
        {
            _text.text = _towerAsset._goldCost.ToString();
            _buyButton.GetComponent<Image>().sprite = _towerAsset._buttonSprite;
            TDPlayer.SubscribeGoldUpdate(CheckCurrentGold);
        }

        #endregion

        #region Public API

        public void BuyTower()
        {
            TDPlayer.Instance.TryBuildTower(_towerAsset, _buildPosition);
        }

        #endregion

        #region Private API

        private void CheckCurrentGold(int amount)
        {
            if (amount >= _towerAsset._goldCost != _buyButton.interactable)
            {
                _buyButton.interactable = !_buyButton.interactable;
                _text.color = _buyButton.interactable ? Color.white : Color.red;
            }
        }

        #endregion

    }

}
