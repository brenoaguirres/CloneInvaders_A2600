using UnityEngine;

namespace AlienInvaders.Player
{
    public class VehicleState : PlayerState
    {
        #region CONSTRUCTOR
        public VehicleState(PlayerFSM.EState key, Player player) : base(key, player) { }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            base.EnterState();
        }
        #endregion
    }
}