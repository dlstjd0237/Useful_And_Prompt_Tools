using UnityEngine;
using UnityEngine.Audio;

#region 사운드 에디터 설정
#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(SoundManager))]
public class SoundManagerEditor : Editor
{
    const string INFO = "슬라이더 설정 값\n" +
       "--------------------\n" +
       "Slider Min Value : 0.001\n" +
       "Slider Max Value : 1\n\n" +
        "MixerPath : AudioMixer가 들어있는 폴더 주소\n" +
        "예시) Resources/AudioMixer 폴더 안에있는 \n" +
        "      _Mixer 을 가져오고 싶으면\n" +
        "MixerPath 안에다 AudioMixer/_Mixer 을 써주면 된다.";

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox(INFO, MessageType.Info);
        base.OnInspectorGUI();
        SoundManager soundManager = (SoundManager)target;
        // [CustomEditor(typeof(SoundManager))] 에 써져있는 target을 가져옴
        if (GUILayout.Button("사운드 데이터 삭제"))
        {
            soundManager.DeleteSoundData();
        }
    }


}
#endif
#endregion
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private string _mixerPath;
    private AudioMixer _mixer;
    public AudioMixer Mixer
    {
        get
        {
            MixerNullChake();
            return _mixer;
        }
    }
    private void OnEnable()
    {
        MixerNullChake();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            VolumeSetMaster(0.3f);
        }
    }
    public void DeleteSoundData()
    {
        PlayerPrefs.DeleteKey("MasterVolume");
        PlayerPrefs.DeleteKey("MusicVolume");
        PlayerPrefs.DeleteKey("SFXVoluem");
#region 사운드 테스트
#if UNITY_EDITOR

        Debug.Log("사운드 저장 데이터 삭제 됨");
#endif
#endregion
    }

    public void VolumeSetMaster(float volume)
    {
        MixerNullChake();
        _mixer.SetFloat("Master", Mathf.Log10(volume) * 20); PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void VolumeSetMusic(float volume)
    {
        MixerNullChake();
        _mixer.SetFloat("Music", Mathf.Log10(volume) * 20); PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void VolumeSetSFX(float volume)
    {
        MixerNullChake();
        _mixer.SetFloat("SFX", Mathf.Log10(volume) * 20); PlayerPrefs.SetFloat("SFXVoluem", volume);
    }

    /// <summary>
    /// Mixer가 Null인경우 재정의
    /// </summary>
    private void MixerNullChake()
    {
        if (_mixer != null)
            return;
        _mixer = Resources.Load<AudioMixer>(_mixerPath);
    }
}
