using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu]
    public sealed class EnemyAsset : ScriptableObject
    {
        #region Properties

        [Header("Visuals")]
        public Color _color = Color.white;
        public Vector2 _spriteScale = new(2, 2);
        public RuntimeAnimatorController _animations;

        [Header("Stats")]
        public float _moveSpeed;
        public int _hitPoints = 1;
        public int _scoreValue = 1;

        [Header("Parameters")]
        public float _colliderRadius = 0.19f;
        public Vector2 _colliderOffset = new(0, -0.15f);

        #endregion
    }
}

