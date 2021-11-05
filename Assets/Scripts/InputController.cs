using UnityEngine;

namespace DefaultNamespace
{
    public abstract class InputController: MonoBehaviour
    {
        public bool isEnd;
        
        public abstract bool IsWalkPossible(Vector3 DestinationPoint);

        public abstract Vector3 PossibleAxis();

    }
}