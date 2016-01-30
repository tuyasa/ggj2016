using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public UnityEngine.EventSystems.EventSystem eventSystem;

    public CanvasRenderer pause;
    public CanvasRenderer start;
    public CanvasRenderer quit;
    public CanvasRenderer title;
    public CanvasRenderer helperText;
    public CanvasRenderer UIBG;

    public MeshRenderer blackRenderer;

    enum State
    {
        NotStarted,
        HelperText,
        Paused,
        OnGame,
        MiniGame
    }

    State gameState = State.NotStarted;

    public IEnumerator Start()
    {
        DontDestroyOnLoad(this.gameObject); //I want to keep the UI during the whole game

        //AppearSequence
        eventSystem.enabled = false;
        yield return StartCoroutine(FadeFromBlack(1f));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(FadeIn(title, time: 0.4f));
        yield return StartCoroutine(FadeIn(start, time: 0.2f));

        eventSystem.enabled = true;
    }

    public void StartOnClick() {
        StartCoroutine(StartOnClickRoutine());
    }

    IEnumerator StartOnClickRoutine()
    {

        //Start button OnClick() Sequence
        switch (gameState)
        {
            case State.NotStarted:

                yield return StartCoroutine(FadeToBlack(0.4f));
                SceneManager.LoadScene("HouseScene");
                yield return StartCoroutine(FadeFromBlack(0.5f));

                yield return StartCoroutine(FadeOut(title));
                start.GetComponentInChildren<Text>().text = "Continue";
                StartCoroutine(FadeIn(helperText));

                gameState = State.HelperText;

                break;
            case State.HelperText:
                start.GetComponentInChildren<Text>().text = "Resume";
                StartCoroutine(FadeOut(helperText));
                StartCoroutine(FadeIn(pause));
                StartCoroutine(FadeOut(start));
                StartCoroutine(FadeOut(quit));
                StartCoroutine(FadeOut(UIBG));
                StartCoroutine(FadeOut(title));

                gameState = State.OnGame;

                break;
            case State.Paused:
                StartCoroutine(FadeIn(pause));
                StartCoroutine(FadeOut(start));
                StartCoroutine(FadeOut(quit));
                StartCoroutine(FadeOut(title));
                StartCoroutine(FadeOut(UIBG));

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
                StartCoroutine(FadeIn(UIBG));
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

    IEnumerator FadeIn(CanvasRenderer graphic, float target = 1f, float time = 0.2f)
    {
        graphic.SetAlpha(0);
        graphic.gameObject.SetActive(true);

        float t = time;
        while(t>0)
        {
            graphic.SetAlpha(Mathf.Lerp(0, target,1-(t/time)));
            t -= Time.deltaTime;
            yield return null;
        }

        graphic.SetAlpha(target);
    }

    IEnumerator FadeOut(CanvasRenderer graphic,float source = 1f, float time = 0.2f)
    {
        graphic.SetAlpha(source);
        float t = time;
        while (t > 0)
        {
            graphic.SetAlpha(Mathf.Lerp(source,0,1-(t/time)));
            t -= Time.deltaTime;
            yield return null;
        }

        graphic.SetAlpha(0);

        graphic.gameObject.SetActive(false);
    }

    IEnumerator FadeToBlack(float time = 0.2f)
    {
        float t = time;
        while(t>0)
        {
            blackRenderer.material.SetFloat("_Visibility", 1 - (t / time));
            t -= Time.deltaTime;
            yield return null;
        }
        blackRenderer.material.SetFloat("_Visibility", 1);
    }

    IEnumerator FadeFromBlack(float time = 0.2f)
    {
        float t = time;
        while (t > 0)
        {
            blackRenderer.material.SetFloat("_Visibility",t / time);
            t -= Time.deltaTime;
            yield return null;
        }
        blackRenderer.material.SetFloat("_Visibility",0);
    }

}
