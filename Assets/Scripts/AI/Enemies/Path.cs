using SpaceShooter;
using UnityEngine;

namespace TowerDefence
{
    public class Path : MonoBehaviour
    {
        #region Properties
        [SerializeField] private AIPointPatrol[] _points;
        public int Length { get => _points.Length; }
        public AIPointPatrol this[int i] { get => _points[i]; }

        #endregion

        #region Unity Editor

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            foreach (var point in _points)
            {
                Gizmos.DrawSphere(point.transform.position, point.Radius);

            }
        }

        #endregion
    }

}

