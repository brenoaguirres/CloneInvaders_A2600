using UnityEngine;

namespace AlienInvaders.Ship
{
    public class IdleState : ShipState
    {
        #region CONSTRUCTOR
        public IdleState(ShipFSM.EState key, Ship ship) : base(key, ship) { }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            base.EnterState();
        }
        #endregion
    }
}