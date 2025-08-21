using AlienInvaders.Interfaces;
using AlienInvaders.Player;
using AlienInvaders.Tools.StateMachine;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace AlienInvaders.Ship
{
    public class ShipFSM : StateMachine<ShipFSM.EState>
    {
        #region ENUMS
        public enum EState
        {
            IDLE,
            MOVE,
            SHOOT,
        }
        #endregion

        #region FIELDS
        private Ship _ship;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            InitializeReferences();
            CheckAssertions();
            InitializeStates();
        }

        private void Start()
        {
            InitializeSubSystems();
        }
        #endregion

        #region INITIALIZATION METHODS
        private void InitializeReferences()
        {
            _ship = GetComponentInChildren<Ship>();
        }

        private void CheckAssertions()
        {
            Assert.IsNotNull(_ship);
        }

        private void InitializeSubSystems()
        {
            GetComponentsInChildren<MonoBehaviour>().Where(mB => mB is IInitializable)
                .ToList()
                .ForEach(subSystem => ((IInitializable)subSystem).Init());
        }

        private void InitializeStates()
        {
            States.Add(EState.IDLE, new IdleState(EState.IDLE, _ship));
            States.Add(EState.MOVE, new MoveState(EState.MOVE, _ship));
            States.Add(EState.SHOOT, new ShootState(EState.SHOOT, _ship));

            _currentState = States[EState.IDLE];
        }
        #endregion
    }
}