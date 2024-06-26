using System;
using UnityEngine;
using UnityEngine.UIElements; //UIToolkit 선언
public class ConfirmationModal : MonoBehaviour
{
    //UI가 담겨져 있는 UIDocument
    private UIDocument _doc;
    //클래스를 적용했다 해제할 UI
    private VisualElement _confirmationModal;
    //타이틀 레이블
    private Label _titleLabel;
    //내용 레이블
    private Label _descriptionLabel;
    //취소 버튼
    private Button _cancelBtn;
    //확인 버튼
    private Button _checkBtn;
    //클릭 이벤트
    private Action _currentCheckBtnClickEvent;

    private void Awake()
    {
        //스크립트가 붙어있는 오브젝트에서 UIDocument를 가져오기
        _doc = gameObject.GetComponent<UIDocument>();

        //UI에서 가장 위에 존재하는 UI VisualElement로 가져오기
        VisualElement root = _doc.rootVisualElement;

        //<> 안에는 가져올 UI의 타입()안에는 가져올 UI의 이름


        //rootUI 안에 있는 confirmation_modal_root_visual_contain-box 라는 이름의 VisualElement형식의 UI를 _titleLabel에 넣어준다.
        _confirmationModal = root.Q<VisualElement>("confirmation_modal_root_visual_contain-box");

        //rootUI 안에 있는 confirmation_modal_title-label라는 이름의 Label형식의 UI를 _titleLabel에 넣어준다.
        _titleLabel = root.Q<Label>("confirmation_modal_title-label");
        //rootUI 안에 있는 confirmation_modal_description-label라는 이름의 Label형식의 UI를 _descriptionLabel에 넣어준다.
        _descriptionLabel = root.Q<Label>("confirmation_modal_description-label");

        //rootUI 안에 있는 confirmation_modal_cancel-btn라는 이름의 Button형식의 UI를 _cancelBtn 넣어준다.
        _cancelBtn = root.Q<Button>("confirmation_modal_cancel-btn");
        //rootUI 안에 있는 confirmation_modal_check-btn라는 이름의 Button형식의 UI를 _checkBtn 넣어준다.
        _checkBtn = root.Q<Button>("confirmation_modal_check-btn");

        //취소 버튼을 클릭했을 떄
        _cancelBtn.RegisterCallback<ClickEvent>(evt => ToggleUI()); //UI끄기
        //확인 버튼을 눌렀을 때
        _checkBtn.RegisterCallback<ClickEvent>(evt =>
        {
            if (_currentCheckBtnClickEvent != null)
            {
                //확인 이벤트 실행 
                _currentCheckBtnClickEvent?.Invoke();
                _currentCheckBtnClickEvent = null;
            }
            //UI끄기
            ToggleUI();
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ShowConfirmationModal("디버깅용 타이틀", "이건 디버깅용 내용으로 아무 연관 없습니다.", () => Debug.Log("확인 눌림"));
    }

    /// <summary>
    /// 확인 대화창 화면에 보이기
    /// </summary>
    /// <param name="title">타이틀에 넣을 내용</param>
    /// <param name="description">확인 대화창 내용</param>
    /// <returns></returns>
    public void ShowConfirmationModal(string title, string description, Action checkBtnCliekEvent)
    {
        //UI 키기
        ToggleUI();

        //title의 text에 넣기
        _titleLabel.text = title;
        //_descriptionLabel text에 넣기
        _descriptionLabel.text = description;
        //cliekEvent 업데이트
        _currentCheckBtnClickEvent = checkBtnCliekEvent; 

    }

    private void ToggleUI()
    {
        //Style Class가 붙어있다면 해제 안붙어 있다면 적용
        _confirmationModal.ToggleInClassList("on"); 
    }
}
