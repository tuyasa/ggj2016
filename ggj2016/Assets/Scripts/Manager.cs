using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Manager : MonoBehaviour {

    public CanvasRenderer pause;
    public CanvasRenderer start;
    public CanvasRenderer quit;
    public CanvasRenderer title;
    public CanvasRenderer helperText;

    enum State
    {
        NotStarted,
        HelperText,
        Paused,
        OnGame,
        MiniGame
    }

    State gameState = State.NotStarted;

    public void StartOnClick()
    {
        switch (gameState)
        {
            case State.NotStarted:
                start.GetComponentInChildren<Text>().text = "Continue";
                StartCoroutine(FadeOut(title));
                StartCoroutine(FadeIn(helperText));

                gameState = State.HelperText;

                break;
            case State.HelperText:
                start.GetComponentInChildren<Text>().text = "Resume";
                StartCoroutine(FadeOut(helperText));
                StartCoroutine(FadeIn(pause));
                StartCoroutine(FadeOut(start));
                StartCoroutine(FadeOut(quit));
                StartCoroutine(FadeOut(title));

                gameState = State.OnGame;

                break;
            case State.Paused:
                StartCoroutine(FadeIn(pause));
                StartCoroutine(FadeOut(start));
                StartCoroutine(FadeOut(quit));
                StartCoroutine(FadeOut(title));

                gameState = State.OnGame;

                break;
            case State.OnGame:
            case State.MiniGame:
            default:
                break;
        }

    }

    public void PauseOnClick()
    {
        switch (gameState)
        {
            case State.OnGame:
            case State.MiniGame:
                StartCoroutine(FadeIn(start));
                StartCoroutine(FadeIn(title));
                StartCoroutine(FadeIn(quit));
                StartCoroutine(FadeOut(pause));

                gameState = State.Paused;

                break;
            case State.NotStarted:
            case State.Paused:
            default:
                break;
        }
    }
    
    public void QuitOnClick()
    {
        Application.Quit();
    }

    IEnumerator FadeIn(CanvasRenderer graphic, float time = 0.2f)
    {
        graphic.SetAlpha(0);
        graphic.gameObject.SetActive(true);

        float t = time;
        while(t>0)
        {
            graphic.SetAlpha(1-(t/time));
            t -= Time.deltaTime;
            yield return null;
        }

        graphic.SetAlpha(1);
    }

    IEnumerator FadeOut(CanvasRenderer graphic, float time = 0.2f)
    {
        graphic.SetAlpha(1);
        float t = time;
        while (t > 0)
        {
            graphic.SetAlpha(t / time);
            t -= Time.deltaTime;
            yield return null;
        }

        graphic.SetAlpha(0);

        graphic.gameObject.SetActive(false);
    }

}
