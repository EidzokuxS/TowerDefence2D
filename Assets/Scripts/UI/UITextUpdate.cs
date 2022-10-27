using TMPro;
using UnityEngine;

namespace TowerDefence
{
    public class UITextUpdate : MonoBehaviour
    {
        #region Properties

        public enum UpdateSource { Gold, Life }
        [SerializeField] UpdateSource _source = UpdateSource.Gold;

        private TMP_Text _text;

        #endregion

        #region Unity Events

        private void Start()
        {
            _text = GetComponent<TMP_Text>();

            switch (_source)
            {
                case UpdateSource.Gold:
                    TDPlayer.SubscribeGoldUpdate(UpdateText);
                    break;
                case UpdateSource.Life:
                    TDPlayer.SubscribeHealthUpdate(UpdateText);
                    break;
            }

        }

        #endregion

        #region Private API

        private void UpdateText(int amount)
        {
            _text.text = amount.ToString();
        }

        #endregion

    }
}
