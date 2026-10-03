using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;
using System;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance { get; private set; }

    [SerializeField] private Image fadeImage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
    private void Start()
{
    StartCoroutine(FadeFromBlack(2f));
}

    public IEnumerator FadeToBlack(float duration, Action onComplete = null)
    {
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.color = color;

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            color.a = Mathf.Lerp(0f, 1f, timer / duration);
            fadeImage.color = color;

            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;
        onComplete?.Invoke();
    }
    public IEnumerator FadeFromBlack(float duration, Action onComplete = null)
{
    Color color = fadeImage.color;
    color.a = 1f;
    fadeImage.color = color;

    float timer = 0f;

    while (timer < duration)
    {
        timer += Time.deltaTime;

        color.a = Mathf.Lerp(1f, 0f, timer / duration);
        fadeImage.color = color;

        yield return null;
    }

    color.a = 0f;
    fadeImage.color = color;

    onComplete?.Invoke();
}
 
}