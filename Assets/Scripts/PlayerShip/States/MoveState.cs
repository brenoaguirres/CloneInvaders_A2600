using Adventure.PlayerShip;
using UnityEngine;

namespace Adventure.PlayerShip
{
    public class MoveState : CharacterState
    {
        #region CONSTANTS
        private const float MOVEMENT_THRESHOLD = 0.1f;
        #endregion

        #region CONSTRUCTOR
        public MoveState(Character2D context, CharacterStateMachine.ECharacterState key) : base(context, key)
        {
        }
        #endregion

        #region STATE METHODS
        public override void EnterState() { }

        public override void UpdateState() 
        {
            _context.Movement2D.MoveHorizontal(_context.Inputs2D.Move.x, _context.Rb);
        }

        public override void FixedUpdateState() { }

        public override void ExitState() { }

        public override CharacterStateMachine.ECharacterState GetNextState() 
        { 
            if (Mathf.Abs(_context.Inputs2D.Move.x) < MOVEMENT_THRESHOLD)
            {
                return CharacterStateMachine.ECharacterState.Idle;
            }

            return StateKey; 
        }

        public override void OnTriggerEnter(Collider other) { }

        public override void OnTriggerStay(Collider other) { }

        public override void OnTriggerExit(Collider other) { }

        public override void OnCollisionEnter(Collision collision) { }

        public override void OnCollisionStay(Collision collision) { }

        public override void OnCollisionExit(Collision collision) { }
        #endregion
    }
}