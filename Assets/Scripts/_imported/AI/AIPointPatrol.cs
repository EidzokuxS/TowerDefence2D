using UnityEngine;

namespace SpaceShooter
{
    public class AIPointPatrol : MonoBehaviour
    {
        [SerializeField] private float _radius;
        public float Radius => _radius;

        private static readonly Color GizmoColor = new(1, 0, 0, 0.3f);

        private void OnDrawGizmosSelected()
        {
            print(4 % 3);
            Gizmos.color = GizmoColor;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }

    public class Team
    {
        public string teamName;
        public int noOfPlayers;

        public Team(string name, int playersAmount)
        {
            teamName = name;
            noOfPlayers = playersAmount;
        }

        public void AddPlayer(int count)
        {
            if (count <= 0)
                return;

            noOfPlayers += count;
        }

        public void RemovePlayer(int count)
        {
            if (count <= 0)
                return;

            if (noOfPlayers >= count)
                noOfPlayers -= count;
            else
                return;
        }
    }

    public class Subteam : Team
    {
        public Subteam(string name, int playersAmount)
            : base(name, playersAmount)
        {
            Team team = new(name, playersAmount);
        }

        public void ChangeTeamName(string name)
        {
            teamName = name;
        }
    }

}

