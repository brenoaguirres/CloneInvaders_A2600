using UnityEngine;

namespace AlienInvaders.Interfaces
{
    public interface ICommand
    {
        public void SetReceiver(ICommandReceiver receiver);
        public void Execute();
    }
}