using UnityEngine;

namespace AlienInvaders.Ship
{
    public class ShootState : ShipState
    {
        #region CONSTRUCTOR
        public ShootState(ShipFSM.EState key, Ship ship) : base(key, ship) { }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            base.EnterState();
        }
        #endregion
    }
}