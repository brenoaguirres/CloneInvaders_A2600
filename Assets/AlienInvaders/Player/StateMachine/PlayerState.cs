using AlienInvaders.Tools.LogManager;
using AlienInvaders.Tools.StateMachine;
using UnityEngine;

namespace AlienInvaders.Player
{
    public class PlayerState : BaseState<PlayerFSM.EState>
    {
        #region CONSTRUCTOR
        public PlayerState(PlayerFSM.EState key, Player player) : base(key) 
        { 
            _player = player;
        }
        #endregion

        #region FIELDS
        private Player _player;
        #endregion

        #region CUSTOM METHODS
        public override void EnterState() { LogManager.Instance.LogMessage($"{typeof(PlayerFSM)} - Enter State: {StateKey}"); }
        public override void UpdateState() { }
        public override void FixedUpdateState() { }
        public override void ExitState() { }
        public override PlayerFSM.EState GetNextState() { return StateKey; }
        public override void OnTriggerEnter(Collider other) { }
        public override void OnTriggerStay(Collider other) { }
        public override void OnTriggerExit(Collider other) { }
        public override void OnCollisionEnter(Collision collision) { }
        public override void OnCollisionStay(Collision collision) { }
        public override void OnCollisionExit(Collision collision) { }
        #endregion
    }
}