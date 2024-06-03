using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    [Header("버튼 클릭 시 사용할 클립")]
    [SerializeField] private AudioClip buttonClickSoundClick;

    public void ButtonClickSoundPlay()
    {
        AudioManager.instance.PlayEffectSound(buttonClickSoundClick);
    }
}
