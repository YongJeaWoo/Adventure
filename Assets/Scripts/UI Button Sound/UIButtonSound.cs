using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    [Header("��ư Ŭ�� �� ����� Ŭ��")]
    [SerializeField] private AudioClip buttonClickSoundClick;

    public void ButtonClickSoundPlay()
    {
        AudioManager.instance.PlayEffectSound(buttonClickSoundClick);
    }
}
