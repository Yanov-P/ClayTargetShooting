using UnityEngine;

namespace ClayTargetShooting
{
    public abstract class Interactable : MonoBehaviour
    {
        public bool Selected { get; private set; } = false;

        public abstract void Interact();
        

        public abstract void OnEndFoundAction();

        public void OnFound()
        {
            CancelInvoke();
            OnFoundAction();
            Invoke("OnEndFoundAction", 0.05f);
        }

        public abstract void OnFoundAction();
    }
}
