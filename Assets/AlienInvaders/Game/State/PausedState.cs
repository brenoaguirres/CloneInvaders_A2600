using UnityEngine;

namespace AlienInvaders.Game
{
    public class PausedState : GameState
    {
        #region CONSTRUCTOR
        public PausedState(GameFSM.EState key) : base(key) { }
        #endregion
    }
}