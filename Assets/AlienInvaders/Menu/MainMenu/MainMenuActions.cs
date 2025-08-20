using AlienInvaders.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace AlienInvaders.Menu
{
    public class MainMenuActions : ButtonPlate<MainMenuCommand>
    {
        #region FIELDS
        private List<MainMenuCommand> _mainMenuCommands = new();
        private MainMenu _mainMenu;
        #endregion

        #region UNITY CALLBACKS
        public void Start()
        {
            Initialize();
        }

        public void OnDestroy()
        {
            Cleanup();
        }
        #endregion

        #region INITIALIZATION METHODS
        private void Initialize()
        {
            InitializeReferences();
            CheckAssertions();
            InitializeButtons();
            SetButtonActions(_mainMenu, _mainMenuCommands);
        }

        private void InitializeReferences()
        {
            _mainMenu = GetComponent<MainMenu>();
            _mainMenuCommands = GetComponentsInChildren<MainMenuCommand>().ToList();
        }

        private void CheckAssertions()
        {
            Assert.IsNotNull(_mainMenuCommands, $"{nameof(_mainMenuCommands)} is not assigned in {typeof(MainMenuActions)}.");
        }

        private void Cleanup()
        {

        }
        #endregion
    }
}