using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject follow;
    private Vector3 startPos;
    private void Awake()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        Vector3 newPos = new Vector3(follow.transform.position.x, follow.transform.position.y, startPos.z);
        transform.position = newPos;
    }
}
