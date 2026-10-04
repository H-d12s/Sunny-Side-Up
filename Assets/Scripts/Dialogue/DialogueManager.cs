using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text speakerText;
    [SerializeField] private TMP_Text dialogueText;

    public bool IsDialogueActive { get; private set; }

    private DialogueData currentDialogue;
    private int currentLineIndex;

    private Coroutine typingCoroutine;

    private bool isTyping;
    private bool skipTyping;

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

    public void StartDialogue(DialogueData dialogue)
    {
        if (dialogue == null || dialogue.lines.Count == 0)
            return;

        currentDialogue = dialogue;
        currentLineIndex = 0;

        IsDialogueActive = true;
        dialoguePanel.SetActive(true);

        ShowCurrentLine();
    }

    private void ShowCurrentLine()
    {
        DialogueLine line = currentDialogue.lines[currentLineIndex];

        speakerText.text = line.speaker;
        dialogueText.text = "";

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeLine(line));
    }

    private IEnumerator TypeLine(DialogueLine line)
    {
        isTyping = true;
        skipTyping = false;

        if (line.textSpeed <= 0)
        {
            dialogueText.text = line.text;
            isTyping = false;
            yield break;
        }

        float delay = 1f / line.textSpeed;

        foreach (char character in line.text)
        {
            if (skipTyping)
            {
                dialogueText.text = line.text;
                break;
            }

            dialogueText.text += character;

            yield return new WaitForSeconds(delay);
        }

        dialogueText.text = line.text;
        isTyping = false;
    }

    public void HandleInput()
    {
        if (!IsDialogueActive)
            return;

        // If text is still typing, E instantly finishes the line.
        if (isTyping)
        {
            skipTyping = true;
            return;
        }

        // Otherwise move to the next line.
        if (currentLineIndex < currentDialogue.lines.Count - 1)
        {
            currentLineIndex++;
            ShowCurrentLine();
        }
        else
        {
            CloseDialogue();
        }
    }

    public void CloseDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        IsDialogueActive = false;

        dialoguePanel.SetActive(false);

        currentDialogue = null;
        currentLineIndex = 0;

        isTyping = false;
        skipTyping = false;
    }

    private void OnDestroy()
{
    if (Instance == this)
    {
        Instance = null;
    }
}
}