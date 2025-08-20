using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

namespace AlienInvaders.UI
{
    public class ViewContent : MonoBehaviour
    {
        #region FIELDS
        [Header("View Settings")]
        [SerializeField] private string _viewID = "";
        [SerializeField] private bool _loop = true;
        [SerializeField] private int _defaultPage = 0;

        private List<ViewPage> _pages = new();
        private int _selectedPage = 0;
        #endregion

        #region PROPERTIES
        public string ViewID => _viewID;
        public bool ActiveState { get; set; } = false;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            Initialize();
            CheckAssertions();
        }

        private void Start()
        {
            InitializePages();
        }
        #endregion

        #region INITIALIZATION METHODS
        private void Initialize()
        {
            if (_viewID == "" || _viewID == null)
                throw new NullReferenceException($"{nameof(_viewID)} not initialized on {typeof(ViewContent)} on gameObject {gameObject.name}.");

            _pages = GetComponentsInChildren<ViewPage>().ToList();
            Hide();
        }

        private void InitializePages()
        {
            foreach (var page in _pages)
            {
                page.Content = this;
                page.SetButtons();
            }
        }

        private void CheckAssertions()
        {
            Assert.IsNotNull(_pages, $"{nameof(_pages)} is null on script {typeof(ViewManager)} in gameobject {gameObject.name}.");
        }
        #endregion

        #region PUBLIC METHODS
        public void Show()
        {
            Hide();
            ActiveState = true;

            _selectedPage = Mathf.Max(0, Mathf.Min(_defaultPage, _pages.Count - 1));
            _pages[_selectedPage].gameObject.SetActive(true);

            if (!ActiveState)
                OnContentShow();
            _pages[_selectedPage].OnPageShow();
        }

        public void Show(int index)
        {
            Hide();
            ActiveState = true;

            _selectedPage = Mathf.Max(0, Mathf.Min(index, _pages.Count - 1));
            _pages[_selectedPage].gameObject.SetActive(true);

            if (!ActiveState)
                OnContentShow();
            _pages[_selectedPage].OnPageShow();
        }

        public void Hide()
        {
            ActiveState = false;

            foreach (ViewPage page in _pages)
            {
                if (page.gameObject.activeSelf)
                {
                    page.OnPageHide();
                    page.gameObject.SetActive(false);
                }
            }

            OnContentHide();
        }

        public void HandlePreviousPage()
        {
            _selectedPage--;

            if (!_loop)
            {
                Show(_selectedPage);
            }
            else
            {
                if (_selectedPage < 0)
                {
                    _selectedPage = _pages.Count - 1;
                    Show(_selectedPage);
                }
                else
                    Show(_selectedPage);
            }
        }

        public void HandleNextPage()
        {
            _selectedPage++;

            if (!_loop)
            {
                Show(_selectedPage);
            }
            else
            {
                if (_selectedPage > _pages.Count - 1)
                {
                    _selectedPage = 0;
                    Show(_selectedPage);
                }
                else
                    Show(_selectedPage);
            }
        }

        public virtual void OnContentShow() { }

        public virtual void OnContentHide() { }
        #endregion
    }
}