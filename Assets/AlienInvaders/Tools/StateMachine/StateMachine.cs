using System.Collections.Generic;
using System;
using UnityEngine;

namespace AlienInvaders.Tools.StateMachine
{
    public abstract class StateMachine<EState> : MonoBehaviour where EState : Enum
    {
        #region FIELDS
        protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
        [SerializeField] protected BaseState<EState> _currentState;

        protected bool IsTransitioningState = false;
        #endregion

        #region PROPERTIES
        public string CurrentState => _currentState.StateKey.ToString();
        #endregion

        #region UNITY CALLBACKS
        private void Start()
        {
            _currentState.EnterState();
        }

        private void Update()
        {
            UpdateCycle(_currentState.UpdateState);
        }

        private void FixedUpdate()
        {
            UpdateCycle(_currentState.FixedUpdateState);
        }

        private void OnTriggerEnter(Collider other)
        {
            _currentState.OnTriggerEnter(other);
        }

        private void OnTriggerStay(Collider other)
        {
            _currentState.OnTriggerStay(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _currentState.OnTriggerExit(other);
        }

        private void OnCollisionEnter(Collision collision)
        {
            _currentState.OnCollisionEnter(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            _currentState.OnCollisionStay(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            _currentState.OnCollisionExit(collision);
        }
        #endregion

        #region CUSTOM METHODS
        private void TransitionToState(EState stateKey)
        {
            IsTransitioningState = true;
            _currentState.ExitState();
            _currentState = States[stateKey];
            _currentState.EnterState();
            IsTransitioningState = false;
        }

        private void UpdateCycle(Action updateMethod)
        {
            EState nextStateKey = _currentState.GetNextState();
            if (!IsTransitioningState && nextStateKey.Equals(_currentState.StateKey))
            {
                updateMethod();
            }
            else if (!IsTransitioningState)
            {
                TransitionToState(nextStateKey);
            }
        }
        #endregion
    }
}
