using UnityEngine;

public class gramaphone : MonoBehaviour
{public AudioSource audioSource;
public GameObject volumeupbutton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void IncreaseVolume()
    {
        audioSource.volume += 0.1f;
        if (audioSource.volume >= 1f)
        {
            audioSource.volume = 1f;
            volumeupbutton.SetActive(false);
        }
    }
}
