using UnityEngine;

public class RoomExit : MonoBehaviour, IPlayerTrigger
{
    [Header("Destination")]
    [SerializeField] private string destinationScene;
    [SerializeField] private string destinationSpawnPoint;

    [Header("Requirements")]
    [SerializeField] private bool requiresJournal;

    public void OnPlayerEnter()
    {
        if (requiresJournal && !GameState.Instance.HasReadJournal)
        {
            Debug.Log(
                "I think I'm forgetting something. " +
                "I should look around for a while longer."
            );

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