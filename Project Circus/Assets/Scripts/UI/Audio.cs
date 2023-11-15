using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSliderController : MonoBehaviour
{
    public Slider slider;
    public AudioMixer mixer;
    public string mixerGroup;

    private void Start()
    {
        if (mixer.GetFloat(mixerGroup, out float val))
        {
            slider.value = Remap(val, -80f, 0f, 0f, 1f);
        }
        
    }

    public void ChangeVolume()
    {
        mixer.SetFloat(mixerGroup, Mathf.Log10(slider.value) * 20);
    }
    
    float Remap(float value, float min1, float max1, float min2, float max2) 
    {
        return min2 + (value - min1) * (max2 - min2) / (max1 - min1);
    }
}