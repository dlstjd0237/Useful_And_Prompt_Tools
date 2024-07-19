using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class TitleUI : MonoBehaviour
{
    [SerializeField] private Sprite _titmeIcon;
    [SerializeField] private float _duration;
    [SerializeField] private string _nextSceneName;

    private UIDocument _doc;
    private VisualElement _root;
    private Label _touchLabel;
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        _root = _doc.rootVisualElement;
        _root.RegisterCallback<ClickEvent>(HandleCliekEvent);
        _touchLabel = _root.Q<Label>("touch-label");

        StartCoroutine("BlinkCoroutine");
    }

    private void HandleCliekEvent(ClickEvent evt)
    {
        SceneControlManager.FadeOut(() => SceneManager.LoadScene(_nextSceneName));
        _root.UnregisterCallback<ClickEvent>(HandleCliekEvent);
    }

    private IEnumerator BlinkCoroutine()
    {
        var wait = new WaitForSeconds(_duration);
        while (true)
        {
            _touchLabel.AddToClassList("on");
            yield return wait;
            _touchLabel.RemoveFromClassList("on");
            yield return wait;
        }

    }

#if UNITY_EDITOR
    //private void OnValidate()
    //{
    //    _doc = GetComponent<UIDocument>();
    //    var root = _doc.rootVisualElement;
    //    root.Q<VisualElement>("title_icon-box").style.backgroundImage = new StyleBackground(_titmeIcon);
    //}
#endif

}
