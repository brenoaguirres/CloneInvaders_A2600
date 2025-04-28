using System;
using Adventure.PlayerShip;
using UnityEngine;

namespace Adventure.PlayerShip
{
    public class ShootState : CharacterState
    {
        #region CONSTRUCTOR
        public ShootState(Character2D context, CharacterStateMachine.ECharacterState key) : base(context, key)
        {
        }
        #endregion

        #region STATE METHODS
        public override void EnterState() { }

        public override void UpdateState() { }

        public override void FixedUpdateState() { }

        public override void ExitState() { }

        public override CharacterStateMachine.ECharacterState GetNextState() { return StateKey; }

        public override void OnTriggerEnter(Collider other) { }

        public override void OnTriggerStay(Collider other) { }

        public override void OnTriggerExit(Collider other) { }

        public override void OnCollisionEnter(Collision collision) { }

        public override void OnCollisionStay(Collision collision) { }

        public override void OnCollisionExit(Collision collision) { }
        #endregion
    }
}