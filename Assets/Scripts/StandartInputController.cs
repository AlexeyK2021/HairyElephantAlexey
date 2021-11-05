using UnityEngine;

namespace DefaultNamespace
{
    public class StandartInputController : InputController
    {
        public StandartInputController()
        {
        }

        public override bool IsWalkPossible(Vector3 DestinationPoint)
        {
            return !isEnd;
        }

        public override Vector3 PossibleAxis()
        {
            return isEnd ? Vector3.zero : new Vector3(1, 1, 1);
        }
    }
}