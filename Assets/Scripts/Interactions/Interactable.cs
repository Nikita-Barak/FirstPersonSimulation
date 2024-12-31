using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMessage;

    // Public method to be used by the player.
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact() { }
}
