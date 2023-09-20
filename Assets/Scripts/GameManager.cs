using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uIManager;
    private PlayerController playerController;
    public GameObject startTonel;
    public List<GameObject> newLevels;

    public int countFire = 3;
    public int scoreCount;
    public int bestScoreCount;

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        playerController = FindObjectOfType<PlayerController>();

        if (PlayerPrefs.HasKey("Score"))
        {
            bestScoreCount = PlayerPrefs.GetInt("Score");
            uIManager.scoreText[3].text = bestScoreCount.ToString();
        }
    }

    public void InstantiateLevel()
    {
        newLevels.Add(Instantiate(newLevels[0], new(0, 0, newLevels[0].transform.position.z + 96), newLevels[0].transform.rotation.normalized));
        Destroy(startTonel);
        StartCoroutine(WaitDeleteLevel());
    }

    public void DecreaseFire()
    {
        countFire--;

        if (countFire >= 0)
        {
            uIManager.CalculateDecreaseFireLife(countFire);
        }

        if (countFire <= 0)
        {
            playerController.isAlive = false;
            playerController.fireTorch.SetActive(false);
            uIManager.LoseScrene();

            if (bestScoreCount < scoreCount)
            {
                bestScoreCount = scoreCount;
                PlayerPrefs.SetInt("Score", bestScoreCount);
                
            }

            uIManager.scoreText[2].text = bestScoreCount.ToString();
        }
    }

    public void IncreaseFire()
    {
        if (countFire < 5)
        {
            countFire++;

            uIManager.CalculateIncreaseFireLife(countFire);
        }
    }

    private IEnumerator WaitDeleteLevel()
    {
        yield return new WaitForSeconds(10f);
        Destroy(newLevels[0]);
        newLevels.Remove(newLevels[0]);
    }
}
