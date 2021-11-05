using System;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class EntityController : MonoBehaviour
    {
        public Transform[] waypoints;
        protected InputController Inputer;
        
        public double speed;
        public double error;
        protected Vector3 DestinationPoint;
        protected int stage = 0;

        public abstract void UpdateEntityWalk();

        protected bool IsOnNextPoint(Vector3 currentPosition, Vector3 destinationPoint)
        {
            var absoluteError = Math.Sqrt(Math.Pow(currentPosition.x - destinationPoint.x, 2) +
                                          (Math.Pow(currentPosition.y - destinationPoint.y, 2) +
                                           Math.Pow(currentPosition.z - destinationPoint.z, 2)));
            return absoluteError <= error;
        }

        protected abstract Vector3 GetVelocity();

        protected abstract void ChangeFollowingPoint();
    }
}