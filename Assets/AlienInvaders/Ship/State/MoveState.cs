using UnityEngine;

namespace AlienInvaders.Ship
{
    public class MoveState : ShipState
    {
        #region CONSTRUCTOR
        public MoveState(ShipFSM.EState key, Ship ship) : base(key, ship) { }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            base.EnterState();
        }
        #endregion
    }
}