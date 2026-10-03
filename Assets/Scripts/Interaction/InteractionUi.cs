using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private GameObject interactionTextObject;
    [SerializeField] private TMP_Text interactionText;

    public void Show(string text)
    {
        Debug.Log("SHOWING UI: " + text);

        interactionText.text = text;
        interactionTextObject.SetActive(true);
    }

    public void Hide()
    {
        Debug.Log("HIDING UI");

        interactionTextObject.SetActive(false);
    }
}