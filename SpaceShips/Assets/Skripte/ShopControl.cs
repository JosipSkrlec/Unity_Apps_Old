using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopControl : MonoBehaviour
{
    public bool refresh = false;

    int MoonstonesCount;
    int cooldown;
    int DropChance;


    public Text MoonstonesText;
    public Text DropChanceText;
    public Text CooldownText;


    // Start is called before the first frame update
    void Start()
    {
        DropChance = PlayerPrefs.GetInt("DropChance");

        if (DropChance == 0)
        {
            PlayerPrefs.SetInt("DropChance", 10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(refresh == true)
        {
            MoonstonesCount = PlayerPrefs.GetInt("Moonstones");

            MoonstonesText.text = MoonstonesCount.ToString();

            DropChance = PlayerPrefs.GetInt("DropChance");

            DropChanceText.text = DropChance.ToString();

            cooldown = PlayerPrefs.GetInt("PlayerShotCooldown");

            CooldownText.text = cooldown.ToString();
        }


    }

    public void BuyChance()
    {
        MoonstonesCount = PlayerPrefs.GetInt("Moonstones");

        if (MoonstonesCount > 100)
        {
            if (DropChance == 50)
            {
                MoonstonesCount -= 100;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCount);

                DropChance += 10;

                PlayerPrefs.SetInt("DropChance", DropChance);

            }

            if (DropChance == 40)
            {
                MoonstonesCount -= 100;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCount);

                DropChance += 10;

                PlayerPrefs.SetInt("DropChance", DropChance);

            }

            if (DropChance == 30)
            {
                MoonstonesCount -= 100;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCount);

                DropChance += 10;

                PlayerPrefs.SetInt("DropChance", DropChance);

            }

            if (DropChance == 20)
            {
                MoonstonesCount -= 100;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCount);

                DropChance += 10;

                PlayerPrefs.SetInt("DropChance", DropChance);

            }

            if (DropChance == 10)
            {
                MoonstonesCount -= 100;

                PlayerPrefs.SetInt("Moonstones", MoonstonesCount);

                DropChance += 10;

                PlayerPrefs.SetInt("DropChance", DropChance);

            }

            else
            {
                Debug.Log("Chance Upgraded to MAX!");
            }


        }
        else
        {
            Debug.Log("Not enought moonstones");
        }
    }








}
