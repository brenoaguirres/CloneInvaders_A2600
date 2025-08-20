using AlienInvaders.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace AlienInvaders.UI
{
    public class CommandButton : MonoBehaviour
    {
        #region FIELDS
        private ICommand _command;
        private Button _button;
        #endregion

        #region UNITY CALLBACKS
        public void OnDestroy()
        {
            Cleanup();
        }
        #endregion

        #region INITIALIZATION METHODS
        public void Cleanup()
        {
            if (_button != null)
                _button.onClick?.RemoveListener(ExecuteCommand);
        }
        #endregion

        #region PUBLIC METHODS
        public void SetButton(Button btn)
        {
            if (_button != null)
                _button.onClick?.RemoveListener(ExecuteCommand);

            _button = btn;
            _button.onClick?.AddListener(ExecuteCommand);
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
        #endregion
    }
}