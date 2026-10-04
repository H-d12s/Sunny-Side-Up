using UnityEngine;

public class RoomExit : MonoBehaviour, IPlayerTrigger
{
    [Header("Destination")]
    [SerializeField] private string destinationScene;
    [SerializeField] private string destinationSpawnPoint;

    [Header("Requirements")]
    [SerializeField] private bool requiresJournal;

    [Header("Blocked Dialogue")]
    [SerializeField] private DialogueData blockedDialogue;

    public void OnPlayerEnter()
    {
        if (requiresJournal && !GameState.Instance.HasReadJournal)
        {
            DialogueManager.Instance.StartDialogue(blockedDialogue);
            return;
        }

        Debug.Log(
            "Leaving room. Destination: " +
            destinationScene +
            " | Spawn Point: " +
            destinationSpawnPoint
        );
    }
}