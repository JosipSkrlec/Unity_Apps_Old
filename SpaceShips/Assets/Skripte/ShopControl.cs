using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// skripta se bavi nadogradnjom nekih od stats-a
public class ShopControl : MonoBehaviour
{
    // true samo na objektu shopcontrol
    public bool refresh = false;

    // helper variables
    int MoonstonesCountREF;
    int DropChancePREF;

    float cooldownPREF;
    float playerDamagePREF;

    // GUI
    public GameObject NotificationText;
    public Text MoonstonesText;
    public Text DropChanceText;
    public Text CooldownText;
    public Text DamageText;

    // VARIJABLE ZA KOSTANJE UPGREJDA XD
    [Header("UPGRADE VALUE")]
    public int DropChanceMoonstonesCost;
    public int playerShootingCooldownMoonstonesCost;
    public int playerDamageCost;

    [Header("BUTTONS")]
    public Button ButtonChanceUpgrade;
    public Button ButtonCooldownUpgrade;
    public Button ButtonDamageUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        // OVO JE ZA DROP CHANCE
        DropChancePREF = PlayerPrefs.GetInt("DropChance");
        if (DropChancePREF == 0)
        {
            PlayerPrefs.SetInt("DropChance", 10);
        }

        // OVO JE ZA COOLDOWN
        cooldownPREF = PlayerPrefs.GetFloat("playerShootingCooldown");
        if (cooldownPREF == 0.0f)
        {
            PlayerPrefs.SetFloat("playerShootingCooldown", 0.5f);
        }

        // OVO JE ZA DAMAGE
        playerDamagePREF = PlayerPrefs.GetFloat("playerDamage");
        // ako ne postoji zapisano u playerpref postavlja se na default
        if (playerDamagePREF == 0.0f)
        {
            PlayerPrefs.SetFloat("playerDamage", 50.0f);
        }

        Debug.Log("drop chance = " + DropChancePREF + " cooldownref = " + cooldownPREF + " damage = " + playerDamagePREF);


    }

    // Update is called once per frame
    void Update()
    {
        // provjerava svaki frame upgrade lvl
        // nalazi se u shop-u na objektu ShopControl
        if (refresh == true)
        {

            MoonstonesCountREF = PlayerPrefs.GetInt("Moonstones");
            MoonstonesText.text = MoonstonesCountREF.ToString();

            DropChancePREF = PlayerPrefs.GetInt("DropChance");
            DropChanceText.text = DropChancePREF.ToString() + "%";

            cooldownPREF = PlayerPrefs.GetFloat("playerShootingCooldown");
            CooldownText.text = cooldownPREF.ToString();

            playerDamagePREF = PlayerPrefs.GetFloat("playerDamage");
            DamageText.text = playerDamagePREF.ToString();

            // UNABLE BUTTONS IF MAX

            // unable button-e koji su na MAX
            if (DropChancePREF == 30)
            {
                ButtonChanceUpgrade.enabled = false;
            }
            //Debug.Log(cooldownPREF);

            if (cooldownPREF == 0.2f)
            {
                ButtonCooldownUpgrade.enabled = false;
            }
            //if ()
            //{

            //}

        }

    }
    // radi odlicno
    public void BuyChance()
    {
        MoonstonesCountREF = PlayerPrefs.GetInt("Moonstones");

        if (MoonstonesCountREF >= DropChanceMoonstonesCost)
        {
            NotificationText.SetActive(true);
            NotificationText.GetComponent<Text>().text = "Drop Chance Upgraded";
            NotificationText.GetComponent<ActiveObjectToUnactiveAfterSeconds>().enabled = true;

            if (DropChancePREF == 30)
            {
                Debug.Log("NA MAX" + DropChancePREF);


            }

            if (DropChancePREF == 25)
            {
                MoonstonesCountREF -= DropChanceMoonstonesCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                DropChancePREF += 5;

                PlayerPrefs.SetInt("DropChance", DropChancePREF);

            }

            if (DropChancePREF == 15)
            {
                MoonstonesCountREF -= DropChanceMoonstonesCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                DropChancePREF += 10;

                PlayerPrefs.SetInt("DropChance", DropChancePREF);


            }

            if (DropChancePREF == 10)
            {
                MoonstonesCountREF -= DropChanceMoonstonesCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                DropChancePREF += 5;
                PlayerPrefs.SetInt("DropChance", DropChancePREF);


            }

        }

        else
        {
            NotificationText.SetActive(true);
            NotificationText.GetComponent<Text>().text = "Not enought moonstones";
            NotificationText.GetComponent<ActiveObjectToUnactiveAfterSeconds>().enabled = true;

            Debug.Log("Not enought moonstones");
        }
    }
    // fix needed TODO - FACKING NE DELA
    public void BuyCooldown()
    {
        MoonstonesCountREF = PlayerPrefs.GetInt("Moonstones");

        if (MoonstonesCountREF > playerShootingCooldownMoonstonesCost)
        {
            NotificationText.SetActive(true);

            NotificationText.SetActive(true);
            NotificationText.GetComponent<Text>().text = "Cooldown Upgraded";
            NotificationText.GetComponent<ActiveObjectToUnactiveAfterSeconds>().enabled = true;

            cooldownPREF = PlayerPrefs.GetFloat("playerShootingCooldown");

            Debug.Log(cooldownPREF);

            if (cooldownPREF == 0.2f)
            {
                MoonstonesCountREF -= playerShootingCooldownMoonstonesCost;
                Debug.Log("22222222222222222222222222222222222");
                cooldownPREF -= 0.1f;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                PlayerPrefs.SetFloat("playerShootingCooldown", cooldownPREF);

            }
            else if (cooldownPREF == 0.3f)
            {
                MoonstonesCountREF -= playerShootingCooldownMoonstonesCost;
                Debug.Log("33333333333333333333");
                cooldownPREF -= 0.1f;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                PlayerPrefs.SetFloat("playerShootingCooldown", cooldownPREF);


            }
            else if(cooldownPREF == 0.4f)
            {
                MoonstonesCountREF -= playerShootingCooldownMoonstonesCost;
                Debug.Log("44444444444444444444444");
                cooldownPREF -= 0.1f;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                PlayerPrefs.SetFloat("playerShootingCooldown", cooldownPREF);

            }
            else if(cooldownPREF == 0.5f)
            {
                MoonstonesCountREF -= playerShootingCooldownMoonstonesCost;
                Debug.Log("55555555555555555555555555");
                cooldownPREF -= 0.1f;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                PlayerPrefs.SetFloat("playerShootingCooldown", cooldownPREF);

            }

            Debug.Log(cooldownPREF);
        }
        else
        {
            NotificationText.SetActive(true);
            NotificationText.GetComponent<Text>().text = "Not enought Moonstones";
            NotificationText.GetComponent<ActiveObjectToUnactiveAfterSeconds>().enabled = true;
        }
    }

    // radi odlicno
    public void BuyDamage()
    {
        MoonstonesCountREF = PlayerPrefs.GetInt("Moonstones");

        if (MoonstonesCountREF >= playerDamageCost)
        {
            NotificationText.SetActive(true);
            NotificationText.GetComponent<Text>().text = "Damage Upgraded";
            NotificationText.GetComponent<ActiveObjectToUnactiveAfterSeconds>().enabled = true;

            playerDamagePREF = PlayerPrefs.GetFloat("playerDamage");


            if (playerDamagePREF == 450)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);

            }

            else if(playerDamagePREF == 400)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);

            }

            else if(playerDamagePREF == 350)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);


            }

            else if(playerDamagePREF == 300)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);

            }

            else if(playerDamagePREF == 250)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);

            }

            else if(playerDamagePREF == 200)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);


            }

            else if(playerDamagePREF == 150)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);

            }

            else if(playerDamagePREF == 100)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);

            }

            else if(playerDamagePREF == 50)
            {
                MoonstonesCountREF -= playerDamageCost;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCountREF);

                playerDamagePREF += 50;

                PlayerPrefs.SetFloat("playerDamage", playerDamagePREF);


            }

        }

    }// end of buy damage method

} // end of main class
