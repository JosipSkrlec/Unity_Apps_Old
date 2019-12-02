using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float MovementSpeed;
    public bool UpDirection = false;

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.position += Vector3.up * Time.deltaTime * MovementSpeed;
        if (UpDirection == false)
        {
            transform.Translate(-(Vector3.up * Time.deltaTime) * MovementSpeed, Space.Self);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime * MovementSpeed, Space.Self);
        }

    }

}
