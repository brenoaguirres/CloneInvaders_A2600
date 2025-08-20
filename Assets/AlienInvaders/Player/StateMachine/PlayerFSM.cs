using System.Linq;
using AlienInvaders.Interfaces;
using AlienInvaders.Tools.StateMachine;
using UnityEngine;
using UnityEngine.Assertions;

namespace AlienInvaders.Player
{
    public class PlayerFSM : StateMachine<PlayerFSM.EState>
    {
        #region ENUMS
        public enum EState
        {
            MENU,
            CHARACTER,
        }
        #endregion

        #region FIELDS
        private Player _player;
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
            _player = GetComponentInChildren<Player>();
        }

        private void CheckAssertions()
        {
            Assert.IsNotNull(_player);
        }

        private void InitializeSubSystems()
        {
            GetComponentsInChildren<MonoBehaviour>().Where(mB => mB is IInitializable)
                .ToList()
                .ForEach(subSystem => ((IInitializable)subSystem).Init());
        }

        private void InitializeStates()
        {
            States.Add(EState.MENU, new PlayerState(EState.MENU, _player));
            States.Add(EState.CHARACTER, new PlayerState(EState.CHARACTER, _player));

            _currentState = States[EState.MENU];
        }
        #endregion
    }
}