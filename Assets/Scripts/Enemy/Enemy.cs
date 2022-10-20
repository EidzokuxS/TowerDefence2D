using SpaceShooter;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TowerDefence
{
    [RequireComponent(typeof(TD_PatrolController))]
    public class Enemy : MonoBehaviour
    {

        #region Public API

        public void UseAssetSettings(EnemyAsset asset)
        {
            var spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            spriteRenderer.GetComponent<Animator>().runtimeAnimatorController = asset._animations;

            spriteRenderer.color = asset._color;
            spriteRenderer.transform.localScale = new Vector3(asset._spriteScale.x, asset._spriteScale.y, transform.localScale.z);

            GetComponent<SpaceShip>().UseAssetSettings(asset);

            var collider = GetComponentInChildren<CircleCollider2D>();

            collider.radius = asset._colliderRadius;
            collider.offset = asset._colliderOffset;

        }

        [CustomEditor(typeof(Enemy))]

        public class EnemyInspector : Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();

                EnemyAsset asset = EditorGUILayout.ObjectField(null, typeof(EnemyAsset), false) as EnemyAsset;
                if (asset)
                {
                    (target as Enemy).UseAssetSettings(asset);
                }
            }
        }


        #endregion
    }

}

