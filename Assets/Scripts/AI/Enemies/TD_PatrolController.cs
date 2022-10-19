using SpaceShooter;

namespace TowerDefence
{
	public class TD_PatrolController : AIController
	{
		#region Properties
		private Path _path;
		private int pathIndex;
		#endregion

		#region Public API
		public void SetPath(Path newPath)
		{
			_path = newPath;
			pathIndex = 0;
			SetPatrolBehaviour(_path[pathIndex]);
		}

		protected override void GetNewPoint()
		{
			if (_path.Length > ++pathIndex)
			{
				SetPatrolBehaviour(_path[pathIndex]);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		#endregion

	}
}


