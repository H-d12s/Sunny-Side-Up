using UnityEngine;

public class PlayerTriggerDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        IPlayerTrigger playerTrigger = other.GetComponent<IPlayerTrigger>();

        if (playerTrigger != null)
        {
            playerTrigger.OnPlayerEnter();
        }
    }
}