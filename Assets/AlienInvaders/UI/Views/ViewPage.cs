using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace AlienInvaders.UI
{
    public class ViewPage : MonoBehaviour
    {
        #region FIELDS
        [Header("Buttons")]
        [SerializeField] private bool _multiPage = true;
        [SerializeField] private Button _previousButton;
        [SerializeField] private Button _nextButton;

        private ViewContent _content;
        #endregion

        #region PROPERTIES
        public ViewContent Content { get => _content; set => _content = value; }
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            if (!_multiPage) return;

            Initialize();
            CheckAssertions();
        }

        private void OnDestroy()
        {
            Cleanup();
        }
        #endregion

        #region INITIALIZATION METHODS
        private void Initialize()
        {
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            List<Button> btns = GetComponentsInChildren<Button>().ToList();

            if (_previousButton == null && btns[0] != null)
            {
                _previousButton = btns[0];
            }
            if (_nextButton == null && btns[1] != null)
            {
                _nextButton = btns[1];
            }
        }

        private void CheckAssertions()
        {
            Assert.IsNotNull(_previousButton, $"{nameof(_previousButton)} not assigned in {typeof(ViewPage)} script in gameObject {gameObject.name}.");
            Assert.IsNotNull(_nextButton, $"{nameof(_nextButton)} not assigned in {typeof(ViewPage)} script in gameObject {gameObject.name}.");
        }

        private void Cleanup()
        {
            if (!_multiPage) return;

            _previousButton.onClick.RemoveAllListeners();
            _nextButton.onClick.RemoveAllListeners();
        }
        #endregion

        #region PUBLIC METHODS
        public void SetButtons()
        {
            if (_content == null) return;
            if (!_multiPage) return;

            _previousButton.onClick.AddListener(_content.HandlePreviousPage);
            _nextButton.onClick.AddListener(_content.HandleNextPage);
        }
        public virtual void OnPageShow() { }
        public virtual void OnPageHide() { }
        #endregion
    }
}