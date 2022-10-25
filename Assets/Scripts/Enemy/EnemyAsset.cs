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
        public float _moveSpeed = 1f;
        public int _hitPoints = 1;
        public int _damage = 1;

        [Header("Parameters")]
        public float _colliderRadius = 0.19f;
        public Vector2 _colliderOffset = new(0, -0.15f);

        public int _scoreValue = 1;
        public int _killGoldAmount = 1;

        #endregion
    }
}

