using UnityEngine;

namespace Adventure.Game
{
    public class GameManager : MonoBehaviour
    {
        #region SINGLETON
        public static GameManager Instance;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }
}