using AlienInvaders.Interfaces;
using AlienInvaders.Tools.StateMachine;
using UnityEngine;

namespace AlienInvaders.Game
{
    public class GameFSM : StateMachine<GameFSM.EState>, IInitializable
    {
        #region ENUMS
        public enum EState
        {
            LOADING,
            MAIN_MENU,
            IN_GAME,
            PAUSED,
            GAME_OVER,
            RESULT,
        }
        #endregion

        #region PRIVATE METHODS
        private void Initialize()
        {
            InitializeStates();
        }
        private void InitializeStates()
        {
            States.Add(EState.LOADING, new LoadingState(EState.LOADING));
            States.Add(EState.MAIN_MENU, new MainMenuState(EState.MAIN_MENU));
            States.Add(EState.IN_GAME, new InGameState(EState.IN_GAME));
            States.Add(EState.PAUSED, new PausedState(EState.PAUSED));
            States.Add(EState.GAME_OVER, new GameOverState(EState.GAME_OVER));
            States.Add(EState.RESULT, new ResultState(EState.RESULT));
            _currentState = States[EState.LOADING];
        }
        #endregion

        #region IInitializable IMPLEMENTATION
        public bool IsInitialized => false;

        public void Init()
        {
            if (IsInitialized) return;

            Initialize();
        }
        #endregion
    }
}