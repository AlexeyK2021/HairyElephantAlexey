using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class GuiderInputController : InputController
    {
        private NavMeshPath path;
        private bool pathStatus;

        public GuiderInputController()
        {
        }

        public override bool IsWalkPossible(Vector3 DestinationPoint) //перебрать расстояния??? Расстояния до NavMeshObstacle
        {
            pathStatus = NavMesh.CalculatePath(transform.position, DestinationPoint, NavMesh.AllAreas, path);
            if (pathStatus != true || isEnd)
                return false;
            return true;
        }

        public override Vector3 PossibleAxis() //перебрать расстояния??? там где пересекаемся (или близко) то 0
        {
            if (!isEnd)
            {
                return Vector3.one;
            }

            return Vector3.zero;
        }
    }
}