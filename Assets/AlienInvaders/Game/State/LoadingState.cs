using System.Collections;
using UnityEngine;

namespace AlienInvaders.Game
{
    public class LoadingState : GameState
    {
        #region CONSTRUCTOR
        public LoadingState(GameFSM.EState key) : base(key) { }
        #endregion

        #region PROPERTIES
        public bool HasLoaded { get; private set; } = false;
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            base.EnterState();
            HasLoaded = false;
            GameManager.Instance.StartCoroutine(WaitForLoad());
        }

        public override GameFSM.EState GetNextState()
        {
            if (HasLoaded) return GameFSM.EState.MAIN_MENU;
            else return StateKey;
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator WaitForLoad()
        {
            yield return new WaitForSeconds(5f);
            HasLoaded = true;
        }
        #endregion
    }
}