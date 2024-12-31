using UnityEngine;

public class Button : Interactable
{
    [SerializeField] GameObject doors;
    private bool doorOpen;

    protected override void Interact()
    {
        doorOpen = !doorOpen;
        doors.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
