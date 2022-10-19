using UnityEngine;


namespace TowerDefence
{
    public class ModelRotationHandler : MonoBehaviour
    {
        #region Properties

        private Rigidbody2D _rig;
        private SpriteRenderer _renderer;

        #endregion
        #region Unity Events
        private void Start()
        {
            _rig = transform.root.GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
        }
        private void LateUpdate()
        {
            transform.up = Vector2.up;
            if (_rig.velocity.x > 0.01f)
                _renderer.flipX = false;
            else if (_rig.velocity.x < 0.01f)
            {
                _renderer.flipX = true;
            }

        }

        #endregion
    }
}

