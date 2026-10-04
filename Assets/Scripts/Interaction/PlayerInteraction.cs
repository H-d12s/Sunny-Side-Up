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

        // Dialogue gets priority over normal interaction
        if (DialogueManager.Instance.IsDialogueActive)
        {
            DialogueManager.Instance.HandleInput();
            return;
        }

        // Normal E interaction
        IInteractable interactable = detector.CurrentInteractable;

        if (interactable != null && interactable.CanInteract())
        {
            interactable.Interact();
        }
    }
}