using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraMoveAfterStart : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;

    private void Start()
    {
        cinemachine = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void MoveCamera()
    {
        var i = cinemachine.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        i.m_XAxis.m_InputAxisValue = 1;
    }
}
