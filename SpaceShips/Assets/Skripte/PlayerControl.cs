using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    #region Game Cotrol Variables
    // PLAYER VARIABLES
    [SerializeField]
    private float PlayerShootingCooldown;
    public float getPlayerShootingCooldown(){return this.PlayerShootingCooldown; }
    public void setPlayerShootingCooldown(float value){this.PlayerShootingCooldown = value;}

    private float PlayerProjectilelvl;
    public float getPlayerProjectilelvl() { return this.PlayerProjectilelvl; }
    public void setPlayerProjectilelvl(float value) { this.PlayerProjectilelvl = value; }

    // 1 is projectile01(blue)
    // 2 is projectile01(green)
    private int IndicatorForChoosenProjectile;
    public int getIndicatorForChoosenProjectile() { return this.IndicatorForChoosenProjectile; }
    public void setIndicatorForChoosenProjectile(int value) { this.IndicatorForChoosenProjectile = value; }

    public GameObject LosePanel;

    public GameObject HealthIndicatorParent;
    public int PlayerHealth = 3;

    #endregion

    #region Main Objects
    [Header("Projectiles")]
    public GameObject Projectile01;
    public GameObject Projectile02;

    [Header("Bonuses")]
    public GameObject Shield;

    #endregion

    #region Help Variables
    private float time;

    #endregion


    // Start is called before the first frame update
    void Start()
    {



        IndicatorForChoosenProjectile = 1;
        PlayerProjectilelvl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= PlayerShootingCooldown)
        {
            if (IndicatorForChoosenProjectile == 1)
            {
                ShootProjectilelvl(Projectile01);
            }
            if (IndicatorForChoosenProjectile == 1)
            {
                ShootProjectilelvl(Projectile02);
            }

            //----------
            time = 0.0f;
        }

        CheckHealth();
        
    }

    private void CheckHealth()
    {
        for (int x = 0; x <= 4; x++)
        {

            if (PlayerHealth-1 >= x)
            {
                Debug.Log(x + " " + PlayerHealth);
                HealthIndicatorParent.transform.GetChild(x).GetComponent<Image>().enabled = true;
                
            }
            else if (PlayerHealth-1 < x)
            {
                HealthIndicatorParent.transform.GetChild(x).GetComponent<Image>().enabled = false;
            }

            // check for health
            if (PlayerHealth <= 0)
            {
                Time.timeScale = 0.0f;

                LosePanel.SetActive(true);

            }

        }

    }

    void ShootProjectilelvl(GameObject ChoosenProjectile)
    {
        Vector3 PositionOfPlayer = this.gameObject.transform.position;

        if (PlayerProjectilelvl == 0)
        {
            GameObject GO_ForSpawn = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn.name = "ProjectileFromPlayer";
            GO_ForSpawn.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn.transform.position = new Vector3(PositionOfPlayer.x, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (PlayerProjectilelvl == 1)
        {
            GameObject GO_ForSpawn = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn.name = "ProjectileFromPlayer";
            GO_ForSpawn.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn.transform.position = new Vector3(PositionOfPlayer.x - 0.1f, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            GameObject GO_ForSpawn1 = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn1.name = "ProjectileFromPlayer";
            GO_ForSpawn1.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn1.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn1.transform.position = new Vector3(PositionOfPlayer.x + 0.1f, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn1.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (PlayerProjectilelvl == 2)
        {
            GameObject GO_ForSpawn = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn.name = "ProjectileFromPlayer";
            GO_ForSpawn.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn.transform.position = new Vector3(PositionOfPlayer.x - 0.13f, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            GameObject GO_ForSpawn1 = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn1.name = "ProjectileFromPlayer";
            GO_ForSpawn1.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn1.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn1.transform.position = new Vector3(PositionOfPlayer.x + 0.0f, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn1.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            GameObject GO_ForSpawn2 = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn2.name = "ProjectileFromPlayer";
            GO_ForSpawn2.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn2.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn2.transform.position = new Vector3(PositionOfPlayer.x + 0.13f, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn2.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (PlayerProjectilelvl == 3)
        {
            GameObject GO_ForSpawn = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn.name = "ProjectileFromPlayer";
            GO_ForSpawn.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn.transform.position = new Vector3(PositionOfPlayer.x - 0.13f, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            GameObject GO_ForSpawn1 = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn1.name = "ProjectileFromPlayer";
            GO_ForSpawn1.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn1.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn1.transform.position = new Vector3(PositionOfPlayer.x + 0.0f, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn1.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            GameObject GO_ForSpawn2 = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn2.name = "ProjectileFromPlayer";
            GO_ForSpawn2.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn2.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn2.transform.position = new Vector3(PositionOfPlayer.x + 0.13f, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn2.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            GameObject GO_ForSpawn3 = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn3.name = "ProjectileFromPlayer";
            GO_ForSpawn3.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn3.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn3.transform.position = new Vector3(PositionOfPlayer.x, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn3.transform.eulerAngles = new Vector3(0.0f, 0.0f, 20.0f);

            GameObject GO_ForSpawn4 = (GameObject)Instantiate(ChoosenProjectile);
            GO_ForSpawn4.name = "ProjectileFromPlayer";
            GO_ForSpawn4.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
            GO_ForSpawn4.GetComponent<ProjectileMovement>().setUpDirection(true);

            GO_ForSpawn4.transform.position = new Vector3(PositionOfPlayer.x, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn4.transform.eulerAngles = new Vector3(0.0f, 0.0f, -20.0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO - fix bug with shield cooldown
        if (collision.transform.name.Contains("ShieldBonus"))
        {
            Shield.SetActive(true);
            Shield.GetComponent<ActiveObjectToUnactiveAfterSeconds>().setCooldown(5.0f);

            collision.GetComponent<DestroyGameObjectAfterSeconds>().enabled = true;


        }
        //else if (collision.transform.name.Contains("UpgradeBonus"))
        //{

        //}
        else if (collision.transform.name.Contains("Ship"))
        {
            PlayerHealth -= 1;
            Destroy(collision.gameObject);
        }
        else if (collision.transform.name.Contains("UpgradeBonus"))
        {
            if (PlayerProjectilelvl < 3)
            {
                PlayerProjectilelvl++;
            }

            Destroy(collision.gameObject);
        }
        else if (collision.transform.name.Contains("ProjectileFrom"))
        {
            if (collision.GetComponent<ProjectileMovement>().getFriendlyToPlayer() == false)
            {
                if (Shield.activeSelf == true)
                {
                    //Debug.Log("PROJECTILE CHANGE"+ collision.transform.name + " ");
                    collision.gameObject.transform.GetComponent<ProjectileMovement>().setMovementSpeed(10);
                    collision.gameObject.transform.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
                    collision.gameObject.transform.GetComponent<ProjectileMovement>().setUpDirection(true);

                }
                else if (Shield.activeSelf == false)
                {
                    PlayerHealth -= 1;

                    Destroy(collision.gameObject);
                }

            }            

        }

    }



}
