using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampaignControl : MonoBehaviour
{
    #region Campaign Veriables
    public int NumberOfLVL;
    // koliko wave-ova ima toliko mora u enemyformation biti zapisano npr. wave = 3 enemy formation = 3-5-7
    public int NumberOfEnemyWaves;
    public string EnemyFormation;

    public float EnemyAttackCooldown;
    public int EnemyHealth;

    public int MoonstonesReward;


    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenCampaign()
    {
        SceneManager.LoadScene("CampaignScene");

    }

    public void OpenGameSceneAndSetParameters()
    {
        PlayerPrefs.SetInt("CurrentCampaignLVL", NumberOfLVL);
        PlayerPrefs.SetInt("NumberOfEnemyWaves", NumberOfEnemyWaves);
        PlayerPrefs.SetString("LEVELCONTROLFORMATION", EnemyFormation);

        PlayerPrefs.SetFloat("EnemyAttackCooldown", EnemyAttackCooldown);
        PlayerPrefs.SetInt("EnemyHealth", EnemyHealth);

        PlayerPrefs.SetInt("MoonstonesReward", MoonstonesReward);    
               
        SceneManager.LoadScene("Game");
    }




}
