using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    #region Public Variables with Getters & Setters
    public float MovementSpeed;
    public float getMovementSpeed() { return this.MovementSpeed; }
    public void setMovementSpeed(float value) { this.MovementSpeed = value; }

    public bool UpDirection = false;
    public bool getUpDirection() { return this.UpDirection; }
    public void setUpDirection(bool value) { this.UpDirection = value; }

    #endregion

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
