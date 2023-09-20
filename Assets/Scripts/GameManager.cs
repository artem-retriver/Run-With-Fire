using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uIManager;
    private PlayerController playerController;
    public GameObject startTonel;
    public List<GameObject> newLevels;

    public int countFire = 3;

    private void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        playerController = FindObjectOfType<PlayerController>();
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
