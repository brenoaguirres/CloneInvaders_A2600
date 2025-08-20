using UnityEngine;

namespace AlienInvaders.Player
{
    public class MenuState : PlayerState
    {
        #region CONSTRUCTOR
        public MenuState(PlayerFSM.EState key, Player player) : base(key, player) { }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            base.EnterState();
        }
        #endregion
    }
}