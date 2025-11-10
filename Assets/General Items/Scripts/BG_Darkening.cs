using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BG_Darkening : MonoBehaviour
{
    [SerializeField]
    private int defaultAlpha = 0;

    [SerializeField]
    private int fadeOutAlpha = 360;

    [SerializeField]
    private Image img;

    private Coroutine currentFadingCoroutine = null;


    private void Awake()
    {
        if (img == null)
        {
            img = GetComponent<Image>();
        }

        SetAlpha(fadeOutAlpha); // fully black
    }

    private void Start()
    {
        // subscribe to scene change event
        SceneManagement.OnSceneGoingToChange.AddListener(FadeOut);


        // fade In
        FadeIn();
    }

    private void FadeIn()
    {

        float time = SceneManagement.instance.SceneChangeDuration;
        currentFadingCoroutine = StartCoroutine(Fade(defaultAlpha, time));
    }

    private void FadeOut(float duration)
    {
        // stopping the current fading coroutine if any
        if (currentFadingCoroutine != null)
        {
            StopCoroutine(currentFadingCoroutine);
        }

        currentFadingCoroutine = StartCoroutine(Fade(fadeOutAlpha, duration));
    }


    IEnumerator Fade(float Target, float time)
    {
        float Start = img.color.a * 255;
        float elapsed = 0f;

        while (elapsed < time)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(Start, Target, elapsed / time);
            SetAlpha((int)alpha);
            yield return null;
        }

        SetAlpha((int)Target);
    }

    public void SetAlpha(int alpha)
    {
        Color c = img.color;
        c.a = alpha / 255f;
        img.color = c;
    }

}
