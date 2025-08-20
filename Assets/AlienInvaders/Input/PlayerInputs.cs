using AlienInvaders.Tools.Singleton;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Assertions;
using AlienInvaders.Tools.LogManager;

namespace AlienInvaders.Input
{
    public class PlayerInputs : MonoBehaviour
    {
        #region CONSTANTS
        // IMPORTANT: consts to retrieve the name of the action from within the action map. Must match the name within the map.
        private const string MOVE_INPUTACTION = "Move";
        private const string FIRE_INPUTACTION = "Fire";
        #endregion

        #region FIELDS
        [Header("Settings")]
        [SerializeField] private bool _debugMode = true;
        [SerializeField] private GameObject _rebindCanvas;

        private PlayerInput _playerInput;
        private List<InputAction> _inputList = new();

        // IMPORTANT: The InputAction which will store that specific input.
        private InputAction _moveAction;
        private InputAction _fireAction;
        #endregion

        #region PROPERTIES
        // IMPORTANT: The properties to retrieve the input throughout the system.
        public Vector2 Move { get; private set; }
        public bool Fire { get; private set; }
        #endregion

        #region UNITY CALLBACKS
        protected void Start()
        {
            Initialize();
        }

        private void Update()
        {
            UpdateInputs();

            if (_debugMode)
            {
                foreach (var input in _inputList)
                {
                    if (input.WasPressedThisFrame())
                        LogManager.Instance.LogMessage(input.name + " was pressed this frame.");
                }
            }
        }
        #endregion

        #region INITIALIZATION METHODS
        private void Initialize()
        {
            InitializeReferences();
            CheckAssertions();

            SetupInputActions();
            SetupInputCollection();

            if (_rebindCanvas != null)
                RefreshUIBindings();
        }

        private void InitializeReferences()
        {
            _playerInput = GetComponent<PlayerInput>();
        }

        private void CheckAssertions()
        {
            Assert.IsNotNull(_playerInput, $"{nameof(_playerInput)} is null in {typeof(PlayerInputs)}.");
        }
        #endregion

        #region PRIVATE METHODS
        // IMPORTANT: Binds InputActions to an action within an action map, searches using
        // a string with the same name as the action within the map.
        private void SetupInputActions()
        {
            _moveAction = _playerInput.actions[MOVE_INPUTACTION];
            _fireAction = _playerInput.actions[FIRE_INPUTACTION];
        }

        // IMPORTANT: Adds the input to the collection.
        private void SetupInputCollection()
        {
            _inputList.Add(_moveAction);
            _inputList.Add(_fireAction);
        }

        // IMPORTANT: Updates the respective property with info about if the input was pressed this frame.
        private void UpdateInputs()
        {
            Move = _moveAction.ReadValue<Vector2>();
            Fire = _fireAction.WasPressedThisFrame();
        }

        private void RefreshUIBindings()
        {
            _rebindCanvas.gameObject.SetActive(false);
            _rebindCanvas.gameObject.SetActive(true);
        }
        #endregion
    }
}