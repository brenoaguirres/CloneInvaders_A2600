using System;
using UnityEngine;

namespace AlienInvaders.Menu
{
    public class MusicVolumeDownCommand : MainMenuCommand
    {
        #region ICommand IMPLEMENTATION
        public override void Execute()
        {
            if (_receiver == null)
            {
                throw new ArgumentNullException($"Receiver from command {this.GetType()} not assigned.");
            }

            _receiver.MusicVolumeDown();
        }
        #endregion
    }
}