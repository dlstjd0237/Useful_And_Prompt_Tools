using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class SceneControlManager : MonoSingleton<SceneControlManager>
{
    [SerializeField]
    private Image _image;
    private Color _cr;
    private float _fadeCool = 0.5f;

    /// <summary>
    /// 0 -> 1
    /// </summary>
    /// <param name="action"></param>
    public static void FadeOut(Action action) =>
        Instance._fadeOut(action);

    /// <summary>
    /// 1 -> 0
    /// </summary>
    /// <param name="action"></param>
    public static void FadeIn(Action action) =>
     Instance._fadeIn(action);


    private void _fadeIn(Action action)
    {
        _image.raycastTarget = false;
        StartCoroutine(fadeInCo(action));
    }
    private IEnumerator fadeInCo(Action action)
    {
        _cr = _image.color;
        while (_image.color.a >= 0)
        {
            float f = Time.deltaTime / _fadeCool;
            _cr.a -= f;
            _image.color = _cr;
            yield return null;
        }
        action?.Invoke();
    }

    private void _fadeOut(Action action)
    {
        _image.raycastTarget = true;
        StopAllCoroutines();
        StartCoroutine(fadeOutCo(action));
    }
    private IEnumerator fadeOutCo(Action action)
    {
        _cr = _image.color;
        while (_image.color.a <= 1)
        {
            float f = Time.deltaTime / _fadeCool;
            _cr.a += f;

            _image.color = _cr;
            yield return null;
        }
        action?.Invoke();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
    }

    public static void LoadScene(string sceneName) => FadeOut(() => SceneManager.LoadScene(sceneName));

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _fadeIn(() => { });
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
