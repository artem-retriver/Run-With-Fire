using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesScoreAndVolume : MonoBehaviour
{
    private VolumeController volumeController;

    public float saveVolume;

    private void Start()
    {
        volumeController = FindObjectOfType<VolumeController>();

        if (PlayerPrefs.HasKey("Volume"))
        {
            saveVolume = PlayerPrefs.GetFloat("Volume");
            volumeController.musicVolume = saveVolume;
        }
    }

    private void Update()
    {
        saveVolume = volumeController.musicVolume;

        PlayerPrefs.SetFloat("Volume", saveVolume);
    }
}
