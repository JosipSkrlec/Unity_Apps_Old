using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampaignControl : MonoBehaviour
{
    #region Campaign Veriables
    public int NumberOfEnemyWaves;
    public float EnemyAttackCooldown;
    public int SpawnEnemyRandom;
    public string EnemyFormation;

    public int NumberOfLVL;


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
        PlayerPrefs.SetInt("NumberOfEnemyWaves", NumberOfEnemyWaves);
        PlayerPrefs.SetFloat("EnemyAttackCooldown", EnemyAttackCooldown);
        PlayerPrefs.SetFloat("SpawnEnemyRandom", SpawnEnemyRandom);
        PlayerPrefs.SetInt("CurrentCampaignLVL", NumberOfLVL);
        // string should be the same number as numberofenemywaves
        // like if number is 3 then enemyformation should be 3-5-4,
        // numbers from 3-7 included both separated with "-"
        PlayerPrefs.SetString("LEVELCONTROLFORMATION", EnemyFormation);


        SceneManager.LoadScene("Game");
    }




}
