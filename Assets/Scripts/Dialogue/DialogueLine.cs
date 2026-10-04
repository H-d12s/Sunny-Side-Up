using System;

[Serializable]
public class DialogueLine
{
    public string speaker;
    public string text;

    // Characters displayed per second.
    public float textSpeed = 30f;
}