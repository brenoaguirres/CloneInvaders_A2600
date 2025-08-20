using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace AlienInvaders.UI
{
    public class PeriodicIcons : MonoBehaviour
    {
        #region FIELDS
        private List<Image> _icons = new();
        private int _selection = 0;
        #endregion

        #region UNITY CALLBACKS
        public void Start()
        {
            Initialize();
        }
        #endregion

        #region INITIALIZATION METHODS
        private void Initialize()
        {
            _icons = GetComponentsInChildren<Image>().ToList();

            if (_icons == null)
            {
                Debug.LogError($"No icons found under {gameObject.name} {GetType()}.");
                this.enabled = false;
            }

            _selection = _icons.IndexOf(_icons.First(x => x.enabled == true));
        }
        #endregion

        #region PUBLIC METHODS
        public void DisableAllIcons()
        {
            foreach (Image icon in _icons)
                icon.enabled = false;
        }

        public void SetNextIcon()
        {
            _selection++;
            _selection = Mathf.Clamp(_selection, 0, _icons.Count - 1);

            DisableAllIcons();
            _icons[_selection].enabled = true;
        }

        public void SetNextIconLooping()
        {
            _selection++;
            if (_selection >= _icons.Count)
                _selection = 0;

            DisableAllIcons();
            _icons[_selection].enabled = true;
        }

        public void SetIconByIndex(int i)
        {
            i = Mathf.Clamp(i, 0, _icons.Count - 1);
            DisableAllIcons();
            _icons[i].enabled = true;
        }
        #endregion
    }
}