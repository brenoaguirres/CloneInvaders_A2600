using UnityEngine;
using Adventure.Tools.StateMachine;
using System;

namespace Adventure.PlayerShip
{
    [Serializable]
    public class CharacterState : BaseState<CharacterStateMachine.ECharacterState>
    {
        #region CONSTRUCTOR
        public CharacterState(Character2D context, CharacterStateMachine.ECharacterState key) : base(key)
        {
            _context = context; 
        }
        #endregion

        #region FIELDS
        protected Character2D _context;
        #endregion

        #region BASESTATE OVERRIDES
        public override void EnterState()
        {
            throw new NotImplementedException();
        }

        public override void UpdateState()
        {
            throw new NotImplementedException();
        }

        public override void FixedUpdateState()
        {
            throw new NotImplementedException();
        }

        public override void ExitState()
        {
            throw new NotImplementedException();
        }

        public override CharacterStateMachine.ECharacterState GetNextState()
        {
            throw new NotImplementedException();
        }

        public override void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }

        public override void OnTriggerStay(Collider other)
        {
            throw new NotImplementedException();
        }

        public override void OnTriggerExit(Collider other)
        {
            throw new NotImplementedException();
        }

        public override void OnCollisionEnter(Collision collision)
        {
            throw new NotImplementedException();
        }

        public override void OnCollisionStay(Collision collision)
        {
            throw new NotImplementedException();
        }

        public override void OnCollisionExit(Collision collision)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
