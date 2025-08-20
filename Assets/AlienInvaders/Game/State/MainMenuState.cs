using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlienInvaders.Game
{
    public class MainMenuState : GameState
    {
        #region CONSTRUCTOR
        public MainMenuState(GameFSM.EState key) : base(key) { }
        #endregion

        #region STATE METHODS
        public override void EnterState()
        {
            base.EnterState();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }
        #endregion
    }
}