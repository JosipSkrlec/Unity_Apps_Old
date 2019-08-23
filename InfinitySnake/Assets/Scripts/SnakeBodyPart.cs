using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBodyPart : MonoBehaviour
{
    public Transform head;

    void Start()
    {

    }

    private Vector3 movementVelocity;
    [Range(0.0f, 1.0f)]
    public float overTime = 0.5f;
    void FixedUpdate()
    {

         transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, overTime);

    }


}
