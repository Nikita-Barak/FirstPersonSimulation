using UnityEngine;

public class BananaMan : Interactable
{
    [SerializeField] GameObject bananaMan;
    [SerializeField] GameObject textBubble;
    [SerializeField] float messageDisplayTime = 2.0f;
    private bool isDisplayed = false;

    void Start()
    {
        textBubble.SetActive(false);
    }

    protected override void Interact()
    {
        if (!isDisplayed)
        {
            isDisplayed = true;
            textBubble.SetActive(true);
            Invoke(nameof(DisableTextBubble), messageDisplayTime);
        }
    }

    void DisableTextBubble()
    {
        textBubble.SetActive(false);
        isDisplayed = false;
    }
}
