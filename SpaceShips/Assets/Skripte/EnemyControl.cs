using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script communicate with EnemyControl, all the variable value is set in EnemyControl
public class EnemyControl : MonoBehaviour
{
    #region Public Variables with Getters & Setters
    [Header("Projectiles")]
    public GameObject Projectile01;
    public GameObject Projectile02;

    private float timeToReachTarget = 3.0f;
    public float gettimeToReachTarget() { return this.timeToReachTarget; }
    public void settimeToReachTarget(float value) { this.timeToReachTarget = value; }

    private bool ShootEnabled = false;
    public bool getShootEnabled() { return this.ShootEnabled; }
    public void setShootEnabled(bool value) { this.ShootEnabled = value; }

    private bool MoveEnemyFormationOnce = true;
    public bool getMoveEnemyFormationOnce() { return this.MoveEnemyFormationOnce; }
    public void setMoveEnemyFormationOnce(bool value) { this.MoveEnemyFormationOnce = value; }

    private Vector3 startPosition;
    public Vector3 getstartPosition() { return this.startPosition; }
    public void setstartPosition(Vector3 value) { this.startPosition = value; }

    private Vector3 targetPosition;
    public Vector3 gettargetPosition(){return this.targetPosition;}
    public void settargetPosition(Vector3 value){this.targetPosition = value;}
    #endregion

    float timeForMovementFormation;

    private void Start()
    {

    }

    void Update()
    {
        //timeForMovement += Time.deltaTime / timeToReachTarget;
        //transform.localPosition = Vector3.Lerp(startPosition, targetPosition, timeForMovement);

        
        if (MoveEnemyFormationOnce == true)
        {
            timeForMovementFormation += Time.deltaTime / timeToReachTarget;
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, timeForMovementFormation);
            if (timeForMovementFormation >= timeToReachTarget)
            {
                MoveEnemyFormationOnce = false;
            }
        }

        if (ShootEnabled)
        {
            ShootEnabled = false;

            Vector3 PositionOfPlayer = this.gameObject.transform.position;

            GameObject GO_ForSpawn = (GameObject)Instantiate(Projectile01);
            GO_ForSpawn.name = "Projectile";
            GO_ForSpawn.transform.position = new Vector3(PositionOfPlayer.x, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

        }

    }



    //public void SetDestination(Vector3 destination, float time)
    //{
    //    t = 0;
    //    startPosition = transform.position;
    //    timeToReachTarget = time;
    //    target = destination;
    //}


}// Main Class
