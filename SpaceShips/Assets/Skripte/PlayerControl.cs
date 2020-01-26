using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    #region Game Cotrol Variables
    // PLAYER VARIABLES
    [SerializeField]
    // varijabla za brzinu pucanja sa getterima i setterima
    private float PlayerShootingCooldown;
    public float getPlayerShootingCooldown(){return this.PlayerShootingCooldown; }
    public void setPlayerShootingCooldown(float value){this.PlayerShootingCooldown = value;}
    
    // projectilelvl oznacava kako ce player pucati
    private float PlayerDamage;
    public float getPlayerDamage() { return this.PlayerDamage; }
    public void setPlayerDamage(float value) { this.PlayerDamage = value; }

    // kada je upaljena win ili lose scena unable-a se update tu u skripti playercontrol
    private bool playUpdate = true;
    public bool getplayUpdate() { return this.playUpdate; }
    public void setplayUpdate(bool value) { this.playUpdate = value; }

    [Header("Helpers")]
    public GameObject Explosion;

    public GameObject LosePanel;
    public GameObject HealthIndicatorParent;
    public bool healthCheckerbool = false;
    public int PlayerHealth = 3;
    float PlayerProjectilelvl;

    [Header("GUI INFO")]
    public Text PlayerDamageGUI;
    #endregion

    #region Main Objects
    [Header("Projectiles")]
    public GameObject Projectile01;

    [Header("Bonuses")]
    public GameObject Shield;

    #endregion

    #region Helper Variables
    private float time;
    private float time2;
    //bool FastShootingEnabled = false;

    #endregion

    // postavljanje shooting cooldown-a koji se cita iz playerpref koji je prethodno zapisan u shop-u
    // postavlja se player projectile lvl
    void Start()
    {
        ShowInfoOnGUI();

        // OVO JE ZA DAMAGE
        float playerDamagePREF = PlayerPrefs.GetFloat("playerDamage");

        Debug.Log(playerDamagePREF);

        // ako ne postoji zapisano u playerpref postavlja se na default
        if (playerDamagePREF == 0.0f)
        {
            Debug.Log("lose");
            PlayerDamage = 50.0f;

            PlayerDamageGUI.text = PlayerDamage.ToString();
        }
        else
        {
            PlayerDamage = playerDamagePREF;
        }

        // OVO JE ZA COOLDOWN
        float playerShootingCooldownPREF = PlayerPrefs.GetFloat("playerShootingCooldown");
        
        // ako ne postoji zapisano u playerpref postavlja se na default
        if (playerShootingCooldownPREF == 0){PlayerShootingCooldown = 0.5f;}
        else
        {
            PlayerShootingCooldown = playerShootingCooldownPREF;
        }

        PlayerProjectilelvl = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (playUpdate == true)
        {
            // pucanje
            if (time >= PlayerShootingCooldown)
            {
                ShootProjectilelvl(Projectile01);

                time = 0.0f;
            }
            // provjera health-a
            if (healthCheckerbool == true)
            {
                CheckHealth();
            }
        }
        
    }

    private void CheckHealth()
    {
        healthCheckerbool = false;

        for (int x = 0; x <= 2; x++)
        {
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
                playUpdate = false;
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

        else if (collision.transform.name.Contains("Ship"))
        {
            healthCheckerbool = true;
            PlayerHealth -= 1;
            Destroy(collision.gameObject);
        }
        else if (collision.transform.name.Contains("UpgradeBonus"))
        {
            if (PlayerProjectilelvl < 2)
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
                    collision.gameObject.transform.GetComponent<ProjectileMovement>().setMovementSpeed(10);
                    collision.gameObject.transform.GetComponent<ProjectileMovement>().setFriendlyToPlayer(true);
                    collision.gameObject.transform.GetComponent<ProjectileMovement>().setUpDirection(true);

                }
                else if (Shield.activeSelf == false)
                {
                    GameObject ExplosionSpawnedPref = Instantiate(Explosion, this.gameObject.transform.localPosition, Quaternion.identity);
                    ExplosionSpawnedPref.transform.parent = this.transform.parent;
                    ExplosionSpawnedPref.transform.localPosition = this.gameObject.transform.localPosition;

                    healthCheckerbool = true;
                    PlayerHealth -= 1;

                    Destroy(collision.gameObject);
                }

            }            

        }

    }

    void ShowInfoOnGUI()
    {
        float playerDamagePREF = PlayerPrefs.GetFloat("playerDamage");
        PlayerDamageGUI.text = playerDamagePREF.ToString();

    }



}
