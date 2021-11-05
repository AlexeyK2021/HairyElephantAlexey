using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class StandartWalker : EntityController
    {
        private Rigidbody rb;
        public bool IsCycling;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            Inputer = gameObject.AddComponent<StandartInputController>();
        }

        private void Start()
        {
            ChangeFollowingPoint();
        }

        private void Update()
        {
            if (IsOnNextPoint(transform.position, DestinationPoint))
            {
                ChangeFollowingPoint();
            }

            UpdateEntityWalk();
        }

        public override void UpdateEntityWalk()
        {
            if (Inputer.IsWalkPossible(DestinationPoint))
            {
                var position = transform.position;
                Vector3 velocityVector = new Vector3(
                                             DestinationPoint.x - position.x,
                                             DestinationPoint.y - position.y,
                                             DestinationPoint.z - position.z) * (float)speed;

                if (Inputer.PossibleAxis().x < 1)
                {
                    var velocityVectorTemp = velocityVector;
                    velocityVector = new Vector3(0, velocityVectorTemp.y, velocityVectorTemp.z);
                }

                if (Inputer.PossibleAxis().y < 1)
                {
                    var velocityVectorTemp = velocityVector;
                    velocityVector = new Vector3(velocityVectorTemp.x, 0, velocityVectorTemp.z);
                }

                if (Inputer.PossibleAxis().y < 1)
                {
                    var velocityVectorTemp = velocityVector;
                    velocityVector = new Vector3(velocityVectorTemp.x, velocityVectorTemp.y, 0);
                }

                rb.velocity = velocityVector;
            }
        }

        protected override Vector3 GetVelocity()
        {
            return rb.velocity;
        }

        protected override void ChangeFollowingPoint()
        {
            if (Inputer.IsWalkPossible(DestinationPoint))
            {
                if (stage >= waypoints.Length && IsCycling)
                {
                    stage %= waypoints.Length;
                    DestinationPoint = waypoints[stage].GetComponent<Transform>().position;
                }
                else if (stage >= waypoints.Length && !IsCycling)
                {
                    Inputer.isEnd = true;
                    rb.velocity = Vector3.zero;
                }
                else DestinationPoint = waypoints[stage].GetComponent<Transform>().position;
            }
            stage++;
        }
    }
}