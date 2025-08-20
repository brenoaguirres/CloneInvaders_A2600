using UnityEngine;

namespace AlienInvaders.Player
{
    public class CharacterState : PlayerState
    {
        #region CONSTRUCTOR
        public CharacterState(PlayerFSM.EState key, Player player) : base(key, player) { }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            base.EnterState();
        }
        #endregion
    }
}