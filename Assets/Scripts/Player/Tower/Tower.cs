using SpaceShooter;
using UnityEngine;

namespace TowerDefence
{
    public class Tower : MonoBehaviour
    {
        #region Properties
        [SerializeField] private float _radius = 5f;
        private Turret[] _turrets;
        private Destructible _target;
        #endregion


        #region Unity Events
        private void Start()
        {
            _turrets = GetComponentsInChildren<Turret>();
        }

        private void Update()
        {
            TargetTrigger();
        }

        #endregion
        #region Public API

        #endregion

        #region Private API

        private void TargetTrigger()
        {
            if (_target)
            {
                Vector2 targetVector = _target.transform.position - transform.position;
                if (targetVector.magnitude < _radius)
                {
                    foreach (var turret in _turrets)
                    {
                        turret.transform.up = targetVector;
                        turret.Fire();
                    }
                }
                else
                {
                    _target = null;
                }
            }
            else
            {
                var enter = Physics2D.OverlapCircle(transform.position, _radius);
                if (enter)
                {
                    _target = enter.transform.root.GetComponent<Destructible>();
                }
            }
        }

        #endregion

        #region UnityEditor
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }

        #endregion
    }
}

