using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AlienInvaders.UI
{
    public class ViewManager : MonoBehaviour
    {
        #region FIELDS
        [Header("Views")]
        [SerializeField] private List<ViewContent> _views = new List<ViewContent>();
        #endregion

        #region PROPERTIES
        public List<ViewContent> Views => _views;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            if (_views == null) return;
        }
        #endregion

        #region INITIALIZATION METHODS
        private void Initialize()
        {
            _views = FindObjectsByType<ViewContent>(FindObjectsSortMode.None).ToList();
        }
        #endregion

        #region PRIVATE METHODS
        private void HideAll()
        {
            foreach (ViewContent view in _views)
                view.Hide();
        }

        private ViewContent FindByID(string id)
        {
            return _views.Find(x => x.ViewID == id);
        }
        #endregion
    }
}