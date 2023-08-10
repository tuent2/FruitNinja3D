using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image fadeImage;
    private int score;
    private Blade blade;
    private Spawner spawner;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }

    public void NewGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;
        score = 0;
        scoreText.text = score.ToString();
        ClearTheSence();
    }

    public void ClearTheSence()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();

        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>();

        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }

    public void IncreateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void Explore()
    {
        blade.enabled = false;
        spawner.enabled = false;

        StartCoroutine(ExplodeSequence());
    }

    void Start()
    {
        NewGame();
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);

            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);
            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(1f);
        elapsed = 0f;
        NewGame();
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);

            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);
            //Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
    }
}
