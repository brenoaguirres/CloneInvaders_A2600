using UnityEngine;

namespace AlienInvaders.Interfaces
{
    public interface IInitializable
    {
        #region PROPERTIES
        public bool IsInitialized { get; }
        #endregion

        #region PUBLIC METHODS
        public void Init();
        #endregion
    }
}