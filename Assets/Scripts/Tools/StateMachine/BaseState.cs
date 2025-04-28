using UnityEngine;
using System;

namespace Adventure.Tools.StateMachine
{
    [Serializable]
    public abstract class BaseState<EState> where EState : Enum
    {
        #region CONSTRUCTOR
        public BaseState(EState key)
        {
            StateKey = key;
        }
        #endregion

        #region PROPERTIES
        public EState StateKey { get; private set; }
        #endregion

        #region CUSTOM METHODS
        public abstract void EnterState();
        public abstract void UpdateState();
        public abstract void FixedUpdateState();
        public abstract void ExitState();
        public abstract EState GetNextState();
        public abstract void OnTriggerEnter(Collider other);
        public abstract void OnTriggerStay(Collider other);
        public abstract void OnTriggerExit(Collider other);
        public abstract void OnCollisionEnter(Collision collision);
        public abstract void OnCollisionStay(Collision collision);
        public abstract void OnCollisionExit(Collision collision);
        #endregion
    }
}