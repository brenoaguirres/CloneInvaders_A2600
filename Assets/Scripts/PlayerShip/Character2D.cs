using UnityEngine;
using Adventure.Tools.StateMachine;

namespace Adventure.PlayerShip
{
    public class Character2D : MonoBehaviour
    {
        #region FIELDS
        [Header("Behaviour")]
        [Space]
        private Inputs2D _inputs2D;
        private Movement2D _movement2D;

        [Header("References")]
        [Space]
        private Rigidbody _rb;

        [Header("State Machine")]
        [Space]
        private CharacterStateMachine _characterSMachine;
        #endregion

        #region PROPERTIES
        public Inputs2D Inputs2D => _inputs2D;
        public Movement2D Movement2D => _movement2D;
        public Rigidbody Rb => _rb;
        public CharacterStateMachine CharacterSMachine 
        {  
            get => _characterSMachine;
            set
            {
                if (_characterSMachine != null)
                {
                    Debug.LogError("Character State Machine already assigned. Please DO NOT modify the State Machine reference in runtime.");
                    return; 
                }
                _characterSMachine = value;
            }
        }
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _inputs2D = GetComponentInChildren<Inputs2D>(true);
            _movement2D = GetComponentInChildren<Movement2D>(true);
        }
        #endregion
    }
}
