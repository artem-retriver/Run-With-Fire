using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Manager:")]
    private Animator anim;
    private MoveController moveController;
    private GameManager gameManager;
    private Light lightTorch;

    public GameObject fireTorch;
    //private CameraMoveAfterStart moveAfterStart;

    public bool isAlive = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        moveController = GetComponent<MoveController>();
        gameManager = FindObjectOfType<GameManager>();
        lightTorch = GetComponentInChildren<Light>();
        //moveAfterStart = FindObjectOfType<CameraMoveAfterStart>();
        //anim.Play("Idle");
        //IsAlive();
    }

    public void Update()
    {
        if (isAlive == true)
        {
            moveController.InputHandler();
        }
        else
            return;
    }

    public void FixedUpdate()
    {
        if (isAlive == true)
        {
            moveController.Movebale();
            moveController.Move();
        }
        else
        {
            moveController.UnMove();
        }
        return;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Tonel _))
        {
            gameManager.InstantiateLevel();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fire _))
        {
            other.gameObject.SetActive(false);
            gameManager.IncreaseFire();

            lightTorch.range = gameManager.countFire * 2;

            StartCoroutine(WaitActiveFire(other));
        }

        if (other.TryGetComponent(out Water _))
        {
            gameManager.DecreaseFire();

            lightTorch.range = gameManager.countFire * 2;
        }
    }

    public void IsAlive()
    {
        StartCoroutine(WaitGameCoroutine());
    }

    private IEnumerator ScoreTimer()
    {
        while(isAlive == true)
        {
            gameManager.scoreCount++;
            gameManager.uIManager.scoreText[0].text = gameManager.scoreCount.ToString();

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator WaitActiveFire(Collider collider)
    {
        yield return new WaitForSeconds(3f);
        collider.gameObject.SetActive(true);
    }

    private IEnumerator WaitGameCoroutine()
    {
        yield return new WaitForSeconds(5f);
        //moveAfterStart.OffCamera();
        isAlive = true;
        anim.Play("Run");

        StartCoroutine(ScoreTimer());
    }
}
