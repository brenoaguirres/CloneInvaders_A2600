using UnityEngine;

namespace Adventure.PlayerShip
{
    public class Inputs2D : MonoBehaviour
    {
        #region FIELDS
        private PlayerInputs _myInputs;

        private Vector2 _movement;
        private bool _fire;
        #endregion

        #region PROPERTIES
        public Vector2 Movement => _movement;
        public bool Fire => _fire;
        #endregion

        #region UNITY CALLBACKS
        public void Awake()
        {
            _myInputs = new PlayerInputs();
            InitializeInputs();
        }

        public void OnEnable()
        {
            InitializeInputs();
        }

        public void OnDisable()
        {
            CleanupInputs();
        }
        #endregion

        #region CUSTOM METHODS
        public void InitializeInputs()
        {
            _myInputs.Enable();

            _myInputs.Player.Move.started += ctx => _movement = ctx.ReadValue<Vector2>();
            _myInputs.Player.Move.performed += ctx => _movement = ctx.ReadValue<Vector2>();
            _myInputs.Player.Move.canceled += ctx => _movement = ctx.ReadValue<Vector2>();

            _myInputs.Player.Fire.started += ctx => _fire = ctx.ReadValueAsButton();
            _myInputs.Player.Fire.performed += ctx => _fire = ctx.ReadValueAsButton();
            _myInputs.Player.Fire.canceled += ctx => _fire = ctx.ReadValueAsButton();
        }

        public void CleanupInputs()
        {
            _myInputs.Disable();
        }
        #endregion
    }
}