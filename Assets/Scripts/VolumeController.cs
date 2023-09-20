using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource[] audioSources;
    public GameObject[] imageVolume;
    public Slider slider;
    public float musicVolume = 1;

    private void Update()
    {
        slider.value = musicVolume;

        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = musicVolume;
        }

        if (musicVolume == 0)
        {
            imageVolume[0].SetActive(false);
            imageVolume[1].SetActive(true);
        }
        else
        {
            imageVolume[0].SetActive(true);
            imageVolume[1].SetActive(false);
        }
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
