using UnityEngine;

namespace AlienInvaders.Player
{
    public class Player : MonoBehaviour
    {
        #region MVC
        [Header("Player Data")]
        [SerializeField] private PlayerModel _model;
        private PlayerView _view = new();
        private PlayerController _controller = new();

        public PlayerModel Model => _model;
        public PlayerView View => _view;
        public PlayerController Controller => _controller;
        #endregion
    }
}