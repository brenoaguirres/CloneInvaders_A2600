using AlienInvaders.Interfaces;
using AlienInvaders.Tools.LogManager;
using UnityEngine;

namespace AlienInvaders.Menu
{
    public class MainMenu : MonoBehaviour, ICommandReceiver
    {
        #region FIELDS
        #endregion

        #region PUBLIC METHODS
        public void StartGame()
        {
            LogManager.Instance.LogMessage($"Started Game.");
        }
        public void OptionsToggle()
        {
            LogManager.Instance.LogMessage($"Options Toggle.");
        }
        public void SFXMute()
        {
            LogManager.Instance.LogMessage($"SFX Mute.");
        }
        public void SFXVolumeUp()
        {
            LogManager.Instance.LogMessage($"SFX Volume Up.");
        }
        public void SFXVolumeDown()
        {
            LogManager.Instance.LogMessage($"SFX Volume Down.");
        }
        public void MusicMute()
        {
            LogManager.Instance.LogMessage($"Music Mute.");
        }
        public void MusicVolumeUp()
        {
            LogManager.Instance.LogMessage($"Music Volume Up.");
        }
        public void MusicVolumeDown()
        {
            LogManager.Instance.LogMessage($"Music Volume Down");
        }
        public void BackPage()
        {
            LogManager.Instance.LogMessage($"Back Page.");
        }
        #endregion
    }
}