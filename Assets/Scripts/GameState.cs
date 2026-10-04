using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    public bool HasReadJournal { get; private set; }

    private void Awake()
    {
        // Make sure there is only one GameState
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Keep GameState when changing scenes
        DontDestroyOnLoad(gameObject);
    }

    public void MarkJournalAsRead()
    {
        HasReadJournal = true;
    }
}