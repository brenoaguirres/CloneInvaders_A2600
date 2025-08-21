using AlienInvaders.Input;
using UnityEngine;

namespace AlienInvaders.Ship
{
    public class Ship : MonoBehaviour
    {
        #region FIELDS
        private PlayerInputs _inputs;
        private Movement _movement;
        private Rigidbody _rigidbody;
        private Animator _animator;
        private ShipFSM _stateMachine;
        #endregion

        #region PROPERTIES
        public PlayerInputs Inputs => _inputs;
        public Movement Movement => _movement;
        public Rigidbody Rb => _rigidbody;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _stateMachine = GetComponent<ShipFSM>();
            _animator = GetComponentInChildren<Animator>();
            _inputs = GetComponentInChildren<PlayerInputs>(true);
            _movement = GetComponentInChildren<Movement>(true);
        }
        #endregion
    }
}