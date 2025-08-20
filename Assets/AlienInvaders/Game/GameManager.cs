using Adventure.Tools.LogManager;
using UnityEngine;

namespace AlienInvaders.Game
{
    public class GameManager : MonoBehaviour
    {
        #region SINGLETON
        public static GameManager Instance;
        #endregion

        #region PROPERTIES
        public GameFSM GameFSM { get; private set; }
        public string CurrentState => GameFSM.CurrentState;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            Initialize();
        }
        #endregion

        #region PRIVATE METHODS
        private void Initialize()
        {
            InitializeSingleton();
            InitializeFSM();
        }
        private void InitializeSingleton()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        private void InitializeFSM()
        {
            GameFSM = GetComponentInChildren<GameFSM>();

            if (GameFSM != null)
                GameFSM.Init();
            else
                LogManager.Instance.LogMessage($"{nameof(GameFSM)} not initialized properly on {typeof(GameManager)}.");
        }
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}