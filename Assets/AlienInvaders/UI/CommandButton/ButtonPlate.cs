using AlienInvaders.Interfaces;
using AlienInvaders.Tools.LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AlienInvaders.UI
{
    public abstract class ButtonPlate<T> : MonoBehaviour where T : ICommand
    {
        #region FIELDS
        protected List<T> _gameCommandList = new();
        protected List<Button> _buttonList = new();
        protected List<CommandButton> _commandButtonList = new();
        #endregion

        #region INITIALIZATION METHODS
        protected virtual void InitializeButtons()
        {
            _buttonList = GetComponentsInChildren<Button>().ToList();
            _commandButtonList = GetComponentsInChildren<CommandButton>().ToList();
        }
        #endregion

        #region PROTECTED METHODS
        protected void SetButtonActions(ICommandReceiver receiver, List<T> commands)
        {
            if (commands == null || _commandButtonList == null)
            {
                LogManager.Instance.LogMessage(($"Nor {nameof(commands)} neither {nameof(_commandButtonList)} can be null."));
                throw new ArgumentNullException($"Nor {nameof(commands)} neither {nameof(_commandButtonList)} can be null.");
            }

            if (commands.Count != _commandButtonList.Count)
            {
                LogManager.Instance.LogMessage($"CommandList '{nameof(commands)}' size must match with ButtonList {nameof(_commandButtonList)} size. Please fix in inspector.");
                throw new ArgumentException($"CommandList '{nameof(commands)}' size must match with ButtonList {nameof(_commandButtonList)} size. Please fix in inspector.");
            }

            _gameCommandList = commands;
            int i = 0;
            foreach (var command in _gameCommandList)
            {
                command.SetReceiver(receiver);
                _commandButtonList[i].SetCommand(command);
                _commandButtonList[i].SetButton(_buttonList[i]);
                i++;
            }
        }
        #endregion
    }
}