using AlienInvaders.Tools.LogManager;
using AlienInvaders.Tools.StateMachine;
using UnityEngine;

namespace AlienInvaders.Game
{
    public class GameState : BaseState<GameFSM.EState>
    {
        #region CONSTRUCTOR
        public GameState(GameFSM.EState key) : base(key) { }
        #endregion

        #region STATE METHODS
        public override void EnterState() { LogManager.Instance.LogMessage($"{typeof(GameState)}: " + StateKey ); }
        public override void UpdateState() { }
        public override void FixedUpdateState() { }
        public override void ExitState() { }
        public override GameFSM.EState GetNextState() { return StateKey; }
        public override void OnCollisionEnter(Collision collision) { }
        public override void OnCollisionExit(Collision collision) { }
        public override void OnCollisionStay(Collision collision) { }
        public override void OnTriggerEnter(Collider other) { }
        public override void OnTriggerExit(Collider other) { }
        public override void OnTriggerStay(Collider other) { }
        #endregion
    }
}