using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        Vector3 _newPosition = new Vector3(offset.x + player.position.x, transform.position.y, offset.z + player.position.z - 7.5f);
        transform.position = _newPosition;
    }
}
