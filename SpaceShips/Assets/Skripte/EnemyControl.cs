using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is used to control enemy invidualy
/// <para>enemy health, explosion after death,projectil which will use</para> 
/// <para>move from starting position to target position</para> 
/// </summary>
public class EnemyControl : MonoBehaviour
{
    #region Public Variables with Getters & Setters
    [Header("Enemy Info")]
    public float Health;
    public float getHealth() { return this.Health; }
    public void setHealth(float value) { this.Health = value; }

    [Header("Projectiles and Game Pref")]
    // projectiles which enemy can spawn
    public GameObject Projectile01;
    public GameObject Projectile02;
    // game object for explosion
    public GameObject Explosion;
    public GameObject Shield;
    public GameObject Upgrade;

    public int DropChance = 10;
    public int getDropChance() { return this.DropChance; }
    public void setDropChance(int value) { this.DropChance = value; }

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

    void Update()
    {
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
            GO_ForSpawn.GetComponent<ProjectileMovement>().setFriendlyToPlayer(false); 

            GO_ForSpawn.name = "ProjectileFromEnemy";
            GO_ForSpawn.transform.position = new Vector3(PositionOfPlayer.x, PositionOfPlayer.y, PositionOfPlayer.z);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("ProjectileFrom"))
        {
            // ako je fendly za player-a tada nije za enemy-a
            if (collision.GetComponent<ProjectileMovement>().getFriendlyToPlayer() == true)
            {
                GameObject PLAYER = GameObject.Find("Player");

                float playerDamage = PLAYER.GetComponent<PlayerControl>().getPlayerDamage();

                Health -= playerDamage;

                if (Health <= 0.0f)
                {
                    GameObject ExplosionSpawnedPref = Instantiate(Explosion, this.gameObject.transform.localPosition, Quaternion.identity);
                    ExplosionSpawnedPref.transform.parent = this.transform.parent;
                    ExplosionSpawnedPref.transform.localPosition = this.gameObject.transform.localPosition;

                    // TODO - napraviti chance za spawn shield-a
                    // SPAWN SHIELD

                    int randomChance = Random.Range(0, 100);

                    if (randomChance < DropChance)
                    {
                        int a = Random.Range(1, 3);
                        if (a == 1)
                        {
                            GameObject ShieldPref = Instantiate(Shield, transform.position, Quaternion.identity);
                            ShieldPref.transform.parent = null;
                            ShieldPref.transform.position = transform.position;
                        }
                        else if (a == 2)
                        {
                            GameObject UpgradePref = Instantiate(Upgrade, transform.position, Quaternion.identity);
                            UpgradePref.transform.parent = null;
                            UpgradePref.transform.position = transform.position;

                        }
                    }
                 

                    Destroy(this.gameObject);
                }
                
                Destroy(collision.transform.gameObject);

            }
        }      

    }


}// Main Class
