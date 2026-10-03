using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;

    public bool IsDialogueActive { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue(string message)
    {
        IsDialogueActive = true;

        dialogueText.text = message;
        dialoguePanel.SetActive(true);
    }

    public void CloseDialogue()
    {
        IsDialogueActive = false;

        dialoguePanel.SetActive(false);
    }
}