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
    public bool healthCheckerbool = false;
    public int PlayerHealth = 3;

    public GameObject SpellIndicatorImage;
    // 0-100
    private int SpecialSpell = 0;
    public int getSpecialSpell() { return this.SpecialSpell; }
    public void setSpecialSpell(int value) { this.SpecialSpell += value; }

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
    private float time2;
    bool FastShootingEnabled = false;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        int playershotcooldown = PlayerPrefs.GetInt("PlayerShotCooldown");

        if (playershotcooldown == 0)
        {
            PlayerShootingCooldown = 0.5f;
        }
        else
        {
            PlayerShootingCooldown = playershotcooldown;
        }

        IndicatorForChoosenProjectile = 1;
        PlayerProjectilelvl = 0;


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;

        if (FastShootingEnabled == true)
        {
            Debug.Log(time + " aasdasd " + time2);
            if (time2 >= 3.0f)
            {
                time2 = 0.0f;
                PlayerShootingCooldown = 0.5f;
                FastShootingEnabled = false;
            }

        }

        if (time >= PlayerShootingCooldown)
        {

            if (IndicatorForChoosenProjectile == 1)
            {
                ShootProjectilelvl(Projectile01);
            }
            if (IndicatorForChoosenProjectile == 2)
            {
                ShootProjectilelvl(Projectile02);
            }

            //----------
            time = 0.0f;
        }

        if (healthCheckerbool == true)
        {
            CheckHealth();
        }
        if (FastShootingEnabled == false)
        {
            CheckIndicatorForSpell();
        }
        
    }

    private void CheckIndicatorForSpell()
    {
        float spellindicatorcounted = SpecialSpell * 0.01f;

        SpellIndicatorImage.GetComponent<Image>().fillAmount = spellindicatorcounted;

        if (spellindicatorcounted >= 1.0f)
        {            
            SpecialSpell = 0;
            spellindicatorcounted = 0.0f;
            time2 = 0.0f;
            SpellIndicatorImage.GetComponent<Image>().fillAmount = 0.0f;
            PlayerShootingCooldown = 0.1f;
            FastShootingEnabled = true;
        }

    }

    private void CheckHealth()
    {
        healthCheckerbool = false;

        for (int x = 0; x <= 4; x++)
        {
            Debug.Log("Povjeravam health-e i uzimam -1");

            if (PlayerHealth-1 >= x)
            {
                Debug.Log(x + " " + PlayerHealth);
                HealthIndicatorParent.transform.GetChild(x).GetComponent<Image>().enabled = true;
                
            }
            else if (PlayerHealth -1 < x)
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
            healthCheckerbool = true;
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
                    healthCheckerbool = true;
                    PlayerHealth -= 1;

                    Destroy(collision.gameObject);
                }

            }            

        }

    }



}
