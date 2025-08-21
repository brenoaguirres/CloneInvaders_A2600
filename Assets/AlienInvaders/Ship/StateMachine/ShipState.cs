using AlienInvaders.Player;
using AlienInvaders.Tools.LogManager;
using AlienInvaders.Tools.StateMachine;
using UnityEngine;

namespace AlienInvaders.Ship
{
    public class ShipState : BaseState<ShipFSM.EState>
    {
        #region CONSTRUCTOR
        public ShipState(ShipFSM.EState key, Ship ship) : base(key) 
        {
            _ship = ship;
        }
        #endregion

        #region FIELDS
        protected Ship _ship;
        #endregion

        #region STATE METHODS
        public override void EnterState() { LogManager.Instance.LogMessage($"{typeof(PlayerFSM)} - Enter State: {StateKey}"); }

        public override void UpdateState() { }

        public override void FixedUpdateState() { }

        public override void ExitState() { }

        public override ShipFSM.EState GetNextState() { return StateKey; }

        public override void OnCollisionEnter(Collision collision) { }

        public override void OnCollisionExit(Collision collision) { }

        public override void OnCollisionStay(Collision collision) { }

        public override void OnTriggerEnter(Collider other) { }

        public override void OnTriggerExit(Collider other) { }

        public override void OnTriggerStay(Collider other) { }
        #endregion
    }
}