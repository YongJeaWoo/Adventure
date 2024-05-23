using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [Header("볼륨 슬라이더")]
    [SerializeField] private Slider volumeSlider;
    
    [Header("사운드 타입")]
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
