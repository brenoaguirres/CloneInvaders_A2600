using AlienInvaders.Tools.LogManager;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AlienInvaders.UI
{
    public abstract class ViewItem : MonoBehaviour
    {
        #region FIELDS
        [Header("View Settings")]

        [Tooltip("ID to find this item in scripts.")]
        [SerializeField] protected string _id = "";

        private static List<ViewItem> _viewItems = new();
        #endregion

        #region PROPERTIES
        public string ID => _id;
        #endregion

        #region EVENTS
        public Action<string> OnValueChanged;
        #endregion

        #region UNITY CALLBACKS
        private void Awake()
        {
            Initialize();
            CheckDuplicates();
        }
        #endregion

        #region INITIALIZATION METHODS
        private void Initialize()
        {
            if (_id == string.Empty) LogManager.Instance.LogMessage($"{nameof(_id)} not initialized on {typeof(ViewItem)}.");
        }
        #endregion

        #region PRIVATE METHODS
        private void CheckDuplicates()
        {
            if (_viewItems.Find(x => x._id == this._id) == null) _viewItems.Add(this);
            else
            {
                LogManager.Instance.LogMessage($"Couldn't add {gameObject.name} {typeof(ViewItem)} to list because of duplicated id: {_id}. Text component will be disabled.");
                gameObject.SetActive(false);
            }
        }
        #endregion

        #region PUBLIC METHODS
        public static ViewItem GetById(string id)
        {
            ViewItem dt = null;

            dt = _viewItems.Find(x => x._id == id);
            if (dt != null) return dt;

            LogManager.Instance.LogMessage($"{typeof(ViewItem)} not found with id: {id}.");
            return dt;
        }
        #endregion
    }
}