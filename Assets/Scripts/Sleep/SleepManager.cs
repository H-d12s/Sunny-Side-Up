using UnityEngine;
using System.Collections;

public class SleepManager : MonoBehaviour
{
    public static SleepManager Instance { get; private set; }

    [SerializeField] private bool canSleep = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

   public void TrySleep()
{
    if (!canSleep)
    {
        DialogueManager.Instance.ShowDialogue("I'm not sleepy.");
        return;
    }

    StartCoroutine(FadeManager.Instance.FadeToBlack(2f, AfterSleep));

}
private void AfterSleep()
{
    StartCoroutine(FadeBackIn());
}

private IEnumerator FadeBackIn()
{
    yield return new WaitForSeconds(1f);

    yield return StartCoroutine(
        FadeManager.Instance.FadeFromBlack(2f)
    );
}
}