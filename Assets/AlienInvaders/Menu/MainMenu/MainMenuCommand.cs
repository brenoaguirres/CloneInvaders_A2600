using AlienInvaders.Interfaces;
using System;
using UnityEngine;

namespace AlienInvaders.Menu
{
    public abstract class MainMenuCommand : MonoBehaviour, ICommand
    {
        #region FIELDS
        protected MainMenu _receiver;
        #endregion

        #region ICommand IMPLEMENTATION
        public virtual void SetReceiver(ICommandReceiver receiver)
        {
            _receiver = receiver as MainMenu;
        }

        public virtual void Execute()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}