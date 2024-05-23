using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [Header("���� �����̴�")]
    [SerializeField] private Slider volumeSlider;
    
    [Header("���� Ÿ��")]
    [SerializeField] private EnumData.E_SoundType soundType;

    private Dictionary<EnumData.E_SoundType, string> mixerParameters = new Dictionary<EnumData.E_SoundType, string>() 
    {
        { EnumData.E_SoundType.Master, "MasterVolume" },
        { EnumData.E_SoundType.BGM, "BGMVolume" },
        { EnumData.E_SoundType.Battle, "BattleVolume" },
        { EnumData.E_SoundType.Effect, "EffectVolume" }
    };

    public void HandleVolumeChange(float _value)
    {
        AudioMixer audioMixer = AudioManager.instance.GetAudioMixer();

        string parameterName;

        if (mixerParameters.TryGetValue(soundType, out parameterName))
        {
            audioMixer.SetFloat(parameterName, Mathf.Log10(_value) * 20);
        }
    }
}
