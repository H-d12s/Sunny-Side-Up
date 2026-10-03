using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private InteractionDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<InteractionDetector>();
    }

   private void Update()
{
    if (!Keyboard.current.eKey.wasPressedThisFrame)
        return;

    // If dialogue is currently open, close it
    if (DialogueManager.Instance.IsDialogueActive)
    {
        DialogueManager.Instance.CloseDialogue();
        return;
    }

    // Otherwise, handle normal interaction
    IInteractable interactable = detector.CurrentInteractable;

    if (interactable != null)
    {
        if (interactable.CanInteract())
        {
            interactable.Interact();
        }
    }
}
}