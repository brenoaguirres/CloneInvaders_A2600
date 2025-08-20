using UnityEngine;
using AlienInvaders.Tools.StateMachine;
using UnityEngine.Assertions;

namespace Adventure.PlayerShip
{
    public class CharacterStateMachine : StateMachine<CharacterStateMachine.ECharacterState>
    {
        #region STATES ENUM
        public enum ECharacterState
        {
            Idle,
            Move,
            Shoot,
        }
        #endregion

        #region FIELDS
        private Character2D _context;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            InitializeContext();
            InitializeStates();
        }
        #endregion

        #region CUSTOM METHODS
        private void InitializeContext()
        {
            _context = GetComponent<Character2D>();
            Assert.IsNotNull(_context, "Character2D context is not assigned.");
            _context.CharacterSMachine = this;
        }

        private void InitializeStates()
        {
            States.Add(ECharacterState.Idle, new IdleState(_context, ECharacterState.Idle));
            States.Add(ECharacterState.Move, new MoveState(_context, ECharacterState.Move));
            States.Add(ECharacterState.Shoot, new ShootState(_context, ECharacterState.Shoot));

            _currentState = States[ECharacterState.Idle];
        }
        #endregion
    }
}
