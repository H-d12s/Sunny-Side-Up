using UnityEngine;

public class ReadJournal : MonoBehaviour, IInteractable
{
    public string GetInteractionText()
    {
        return "E - Open Journal";
    }

    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        Debug.Log("Journal opened.");

        GameState.Instance.MarkJournalAsRead();
    }
}