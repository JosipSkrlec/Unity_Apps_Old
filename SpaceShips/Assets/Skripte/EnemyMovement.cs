using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 startPosition;
    float time;
    public float timeToReachTarget;

    private Vector3 targetPosition;
    public Vector3 gettargetPosition(){return this.targetPosition;}
    public void settargetPosition(Vector3 value){this.targetPosition = value;}

    void Update()
    {
        time += Time.deltaTime / timeToReachTarget;
        transform.localPosition = Vector3.Lerp(startPosition, targetPosition, time);
    }



    //public void SetDestination(Vector3 destination, float time)
    //{
    //    t = 0;
    //    startPosition = transform.position;
    //    timeToReachTarget = time;
    //    target = destination;
    //}


}// Main Class
