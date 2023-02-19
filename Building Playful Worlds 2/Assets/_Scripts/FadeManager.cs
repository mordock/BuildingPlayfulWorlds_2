using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public GameObject fadePanel;
    // Start is called before the first frame update
    void Start() {
        fadePanel.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update() {

    }

    public void fadeToBlack(float fadeTime) {
        StartCoroutine(Fade(fadeTime, 0, 1));
    }

    public void fadeFromBlack(float fadeTime) {
        StartCoroutine(Fade(fadeTime, 1, 0));
    }

    public void fadeToBlackAndBack(float fadeIn, float fadeOut, float holdTime) {
        StartCoroutine(FadeInAndOut(fadeIn, fadeOut, holdTime));
    }

    IEnumerator Fade(float fadeTime, int start, int end) {
        float counter = 0f;
        CanvasGroup group = fadePanel.GetComponent<CanvasGroup>();

        while (counter < fadeTime) {
            counter += Time.deltaTime;
            group.alpha = Mathf.Lerp(start, end, counter / fadeTime);

            yield return null;
        }
    }

    IEnumerator FadeInAndOut(float fadeTimeIn, float fadeTimeOut, float holdTime) {
        float counterIn = 0f;
        float counterOut = 0f;
        CanvasGroup group = fadePanel.GetComponent<CanvasGroup>();

        while (counterIn < fadeTimeIn) {
            counterIn += Time.deltaTime;
            group.alpha = Mathf.Lerp(0, 1, counterIn / fadeTimeIn);

            yield return null;
        }

        yield return new WaitForSeconds(holdTime);

        while (counterOut < fadeTimeOut) {
            counterOut += Time.deltaTime;
            group.alpha = Mathf.Lerp(1, 0, counterOut / fadeTimeOut);

            yield return null;
        }
    }
}
