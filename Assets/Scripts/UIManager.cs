using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public CameraMoveAfterStart afterStart;
    public PlayerController playerController;
    public MoveController moveController;

    public GameObject[] sceneUI;
    public GameObject[] fireLifeOn;
    public GameObject[] fireLifeOff;
    public TextMeshProUGUI[] scoreText;

    private bool infoSceneOn;
    private bool pauseSceneOn;
    private bool settingsSceneOn;

    private void Start()
    {
        afterStart = FindObjectOfType<CameraMoveAfterStart>();
        playerController = FindObjectOfType<PlayerController>();
        moveController = FindObjectOfType<MoveController>();
    }

    public void GameScene()
    {
        sceneUI[0].SetActive(false);
        sceneUI[1].SetActive(false);
        sceneUI[2].SetActive(true);
        sceneUI[3].SetActive(false);

        afterStart.MoveCamera();
        playerController.IsAlive();
    }

    public void CalculateIncreaseFireLife(int fire)
    {
        for (int i = 0; i < fire; i++)
        {
            fireLifeOn[i].SetActive(true);
        }

        for (int i = 0; i < fire; i++)
        {
            fireLifeOff[i].SetActive(false);
        }
    }

    public void CalculateDecreaseFireLife(int fire)
    {
        for (int i = fire; i < fireLifeOn.Length; i++)
        {
            fireLifeOn[i].SetActive(false);
        }

        for (int i = fire; i < fireLifeOff.Length; i++)
        {
            fireLifeOff[i].SetActive(true);
        }
    }

    public void EasyDifficult()
    {
        Difficult(4);
    }

    public void MiddleDifficult()
    {
        Difficult(5);
    }

    public void HardDifficult()
    {
        Difficult(6);
    }

    public void Difficult(int chooseDifficult)
    {
        moveController.speed = chooseDifficult;
        GameScene();
    }

    public void SettingsScene()
    {
        if (settingsSceneOn == false)
        {
            settingsSceneOn = true;
            infoSceneOn = false;
            sceneUI[0].SetActive(false);
            sceneUI[3].SetActive(true);
        }
        else
        {
            settingsSceneOn = false;
            infoSceneOn = false;
            sceneUI[3].SetActive(false);
        }
    }

    public void InfoScene()
    {
        if (infoSceneOn == false)
        {
            infoSceneOn = true;
            settingsSceneOn = false;
            sceneUI[3].SetActive(false);
            sceneUI[0].SetActive(true);
        }
        else
        {
            infoSceneOn = false;
            settingsSceneOn = false;
            sceneUI[0].SetActive(false);
        }
    }

    public void LoseScrene()
    {
        scoreText[1].text = scoreText[0].text;

        sceneUI[2].SetActive(false);
        sceneUI[4].SetActive(true);
        Time.timeScale = 0f;
    }

    public void RepeatScene()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }

    public void PauseScene()
    {
        if (pauseSceneOn == false)
        {
            pauseSceneOn = true;
            Time.timeScale = 0f;
        }
        else
        {
            pauseSceneOn = false;
            Time.timeScale = 1f;
        }
    }
}
