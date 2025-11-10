using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        StartCoroutine(PlaySound(clip));
    }

    private IEnumerator PlaySound(AudioClip clip)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = clip;

        audioSource.Play();

        yield return new WaitForSeconds(clip.length);

        Destroy(audioSource);
    }
}
