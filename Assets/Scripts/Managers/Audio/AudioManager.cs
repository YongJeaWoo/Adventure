using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Awake�� �� �ȿ�
    #region Singleton
    public static AudioManager instance;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private GameObject bgmObject;
    private GameObject battleObject;
    private GameObject effectObject;

    private AudioSource audioSourceBGM;
    private AudioSource audioSourceBattle;
    private AudioSource audioSourceEffect;

    [Header("��� ����")]
    [SerializeField] private AudioClip[] backgroundsMusic;
    [Header("���� ����")]
    [SerializeField] private AudioClip[] battleMusic;
    [Header("ȿ���� ����")]
    [SerializeField] private AudioClip[] effectsMusic;
    [Header("����� �ͼ�")]
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        SetAudioSource();
    }

    private void SetAudioSource()
    {
        bgmObject = new GameObject("BackgroundMusic");
        bgmObject.transform.SetParent(transform);

        battleObject = new GameObject("BattleMusic");
        battleObject.transform.SetParent(transform);

        effectObject = new GameObject("EffectMusic");
        effectObject.transform.SetParent(transform);

        SetAudioSourceComponent();
        PlayRandomBackgroundMusic();
    }

    private void SetAudioSourceComponent()
    {
        for (int i = 0; i < backgroundsMusic.Length; i++)
        {
            audioSourceBGM = bgmObject.AddComponent<AudioSource>();
            audioSourceBGM.playOnAwake = false;
            audioSourceBGM.outputAudioMixerGroup = audioMixer.FindMatchingGroups("BGM")[0];
        }

        for (int i = 0; i < battleMusic.Length; i++)
        {
            audioSourceBattle = battleObject.AddComponent<AudioSource>();
            audioSourceBattle.playOnAwake = false;
            audioSourceBattle.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Battle")[0];
        }

        for (int i = 0; i < effectsMusic.Length; i++)
        {
            audioSourceEffect = effectObject.AddComponent<AudioSource>();
            audioSourceEffect.playOnAwake = false;
            audioSourceEffect.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Effect")[0];
        }
    }

    public void PlayRandomBackgroundMusic()
    {
        if (audioSourceBattle.isPlaying) audioSourceBattle.Stop();

        if (backgroundsMusic.Length > 0)
        {
            int randomIndex = Random.Range(0, backgroundsMusic.Length);
            audioSourceBGM.clip = backgroundsMusic[randomIndex];
            
            if (!audioSourceBGM.isPlaying)
            {
                audioSourceBGM.Play();
            }
        }
    }

    public void PlayEffectSound(AudioClip _clip)
    {
        if (_clip == null) return;
        audioSourceEffect.PlayOneShot(_clip);
    }

    public void PlayBattleMusic(AudioClip _clip)
    {
        if (audioSourceBGM.isPlaying) audioSourceBGM.Stop();

        audioSourceBattle.clip = _clip;
        
        if (!audioSourceBattle.isPlaying)
        {
            Debug.Log($"���� ���");
            Debug.Log($"����� Ŭ�� {audioSourceBattle.clip}");
            audioSourceBattle.Play();
        }
    }

    public AudioMixer GetAudioMixer() => audioMixer;
}
