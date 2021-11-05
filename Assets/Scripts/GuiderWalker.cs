using UnityEngine;
using UnityEngine.AI;

namespace DefaultNamespace
{
    public class GuiderWalker : EntityController
    {
        private Rigidbody rb;
        public NavMeshAgent agent;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            Inputer = gameObject.AddComponent<GuiderInputController>();
        }

        private void Start()
        {
            ChangeFollowingPoint();
        }

        private void Update()
        {
            if (IsOnNextPoint(transform.position, DestinationPoint))
                ChangeFollowingPoint();
            UpdateEntityWalk();
        }

        public override void UpdateEntityWalk()
        {
            agent.SetDestination(DestinationPoint);
            DrawGoingLine(DestinationPoint);
        }


        protected override void ChangeFollowingPoint()
        {
            if (stage >= waypoints.Length) Inputer.isEnd = true;
            else DestinationPoint = waypoints[stage].GetComponent<Transform>().position;
            Debug.Log("Destination:" + DestinationPoint);
            stage++;
        }

        protected override Vector3 GetVelocity()
        {
            return rb.velocity;
        }

        private void DrawGoingLine(Vector3 target)
        {
            NavMeshHit hit;
            bool blocked = false;
            blocked = NavMesh.Raycast(transform.position, target, out hit, NavMesh.AllAreas);
            Debug.DrawLine(transform.position, target, blocked ? Color.red : Color.green);

            if (blocked)
                Debug.DrawRay(hit.position, Vector3.up, Color.red);
        }
    }
}