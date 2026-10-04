using UnityEngine;

public class RoomExit : MonoBehaviour, IPlayerTrigger
{
    public void OnPlayerEnter()
    {
        if (!GameState.Instance.HasReadJournal)
        {
            Debug.Log("I think I'm forgetting something. I should look around for a while longer.");
            return;
        }

        Debug.Log("Leaving the room...");
    }
}