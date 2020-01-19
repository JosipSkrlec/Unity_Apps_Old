using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is used to spawn enemy, choose random enemy ship for shooting from formation
/// <para>spawn enemy from different or same position on the beggining of formation</para> 
/// <para>likewise contains number of waves</para> 
/// </summary>
public class EnemySystemAndInGameControl : MonoBehaviour
{

    #region Main Objects
    [Header("Enemy Ships / Alliance")]
    public GameObject AllianceEnemyShip01;
    public GameObject AllianceEnemyShip02;
    public GameObject AllianceEnemyShip03;

    [Header("Enemy Ships / Resistance")]
    public GameObject ResistanceEnemyShip01;
    public GameObject ResistanceEnemyShip02;
    public GameObject ResistanceEnemyShip03;
    #endregion

    private protected float[] Formation_ArrayX = new float[] { 14.0f, 9.2f, 4.6f, 0.0f, -4.6f, -9.2f, -14.0f }; // 7 numbers //COLUMN
    //private protected float[] Formation_ArrayY = new float[] { -28.0f, -24.0f, -20.0f, -16.0f, -12.0f, -8.0f, -4.0f }; // 8 numbers // ROW
    private protected float[] Formation_ArrayY = new float[] { 72.0f, 76.0f, 80.0f, 84.0f, 88.0f, 92.0f, 96.0f }; // 8 numbers // ROW

    private Vector3 LeftUpperFormationSpawner = new Vector3(60.0f, -30.0f, 0.0f);
    private Vector3 LeftBottomFormationSpawner = new Vector3(40.0f, 0.0f, 0.0f);
    private Vector3 RightUpperFormationSpawner = new Vector3(-60.0f, -30.0f, 0.0f);
    private Vector3 RightBottomrFormationSpawner = new Vector3(-40.0f, 0.0f, 0.0f);

    [Header("Game System Control")]
    public GameObject WinPanel;
    public Text MoonstonesRewardText;
    public Text CountingText;
    public bool CountingSecondsForSpawnFormation = true;
    private int CountingSecondsForSpawnFormationHelper = 0;

    public int NumberOfWaves = 0;
    public int getNumberOfWaves() { return this.NumberOfWaves; }
    public void setNumberOfWaves(int value) { this.NumberOfWaves = value; }

    public float cooldownforShooting = 5.0f;
    public float getcooldownforShooting() { return this.cooldownforShooting; }
    public void setcooldownforShooting(float value) { this.cooldownforShooting = value; }

    public bool MoveFormationLeftAndRightBool = false;
    public bool MoveFormationInCircleBool = false; 
    public bool MoveFormationUpAndDOwnBool = false;

    public int Moonstones = 0;
    public int getMoonstones() { return this.Moonstones; }
    public void setMoonstones(int value) { this.Moonstones = value; }

    //private protected List<string> ListToStoreGameLevelControl = new List<string>();
    //private protected string SaveHelper;

    private protected List<int> NumberInFormation = new List<int>();
    private int PositionOfSpawnFromListHelper = 0;

    bool SpawnFormationBool = false;
    bool SpawnFormationFromSamePosition = true;

    // HELPERS
    float TimeForShooting;
    float TimeForCountThreeSeconds;
    int numberOfTotalWaves;
    bool spawnFirstWaveHelper = true;
    int numberofCurrentWave = 1;

    // spawn first wave
    private void Awake()
    {
        Time.timeScale = 1.0f;

        //first parameter is number of waves
        // second is enemy shooting cooldown
        //third is 0 or 1, for spawn randomm or no
        //PlayerPrefs.SetString("LEVELCONTROL", "1-0-0");
        //first is number in first wave ...
        //in third wave
        //PlayerPrefs.SetString("LEVELCONTROLFORMATION", "7");

        try
        {
            int NumberOfEnemyWaves = PlayerPrefs.GetInt("NumberOfEnemyWaves");
            float EnemyAttackCooldown = PlayerPrefs.GetFloat("EnemyAttackCooldown");
            int SpawnEnemyRandom = PlayerPrefs.GetInt("SpawnEnemyRandom");

            numberOfTotalWaves = NumberOfEnemyWaves;
            NumberOfWaves = NumberOfEnemyWaves; // -1 zbog array counter-a
            cooldownforShooting = EnemyAttackCooldown;

            if (SpawnEnemyRandom == 0) { SpawnFormationFromSamePosition = false; }
            else { SpawnFormationFromSamePosition = true; }



#pragma warning disable CS0168 // Variable is declared but never used
        }
        catch (System.Exception e) { }
#pragma warning restore CS0168 // Variable is declared but never used

    }

    // Start is called before the first frame update
    void Start()
    {
        #region LOAD SAVE EXAMPLE
        //Save_Load SV = new Save_Load(Save_Load.Method_Type.Load, "Save", "a");

        //string SaveHelper = SV.getOutput();

        //string[] SaveParameters = SaveHelper.Split('-');

        //cooldownforShooting = float.Parse(SaveParameters[0], CultureInfo.InvariantCulture.NumberFormat);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        TimeForShooting += Time.deltaTime;

        if (MoveFormationLeftAndRightBool == true)
        {
            MoveFormationLeftAndRight();
        }
        if (MoveFormationInCircleBool == true)
        {
            MoveFormationInCircle();
        }
        if (MoveFormationUpAndDOwnBool == true)
        {
            MoveFormationUpAndDown();
        }

        if (TimeForShooting >= cooldownforShooting)
        {
            TimeForShooting = 0.0f;
            try
            {
                int NumberOfChields = this.gameObject.transform.childCount;
                int RandomChoosenEnemyForShoot = Random.Range(0, NumberOfChields);

                this.gameObject.transform.GetChild(RandomChoosenEnemyForShoot).GetComponent<EnemyControl>().setShootEnabled(true);
            }
            catch (System.Exception) { };
        } // Shooting

        // spawn again when child = 0 or less then 0
        if (this.transform.childCount <= 0)
        {
            if (NumberOfWaves <= 0)
            {
                SpawnFormationBool = false;

                Time.timeScale = 0.0f;

                // campaignlvlcompleted
                int currentplayedlvl = PlayerPrefs.GetInt("CurrentCampaignLVL");
                Debug.Log(currentplayedlvl);
                PlayerPrefs.SetInt("CampaignFinished", currentplayedlvl);

                int CurrentMoonstonesReward = PlayerPrefs.GetInt("CurrentLvlMoonstones");

                MoonstonesRewardText.text = CurrentMoonstonesReward.ToString();

                WinPanel.SetActive(true);                

            }
            else
            {
                if (CountingSecondsForSpawnFormation == true)
                {
                    TimeForCountThreeSeconds += Time.deltaTime;

                    if (TimeForCountThreeSeconds >= 1.0f && CountingSecondsForSpawnFormationHelper < 4)
                    {
                        TimeForCountThreeSeconds = 0.0f;
                        CountingSecondsForSpawnFormationHelper += 1;

                        CountingText.gameObject.SetActive(true);
                        CountingText.text = numberofCurrentWave + "/" + numberOfTotalWaves;
                        //CountingText.text = (4 - CountingSecondsForSpawnFormationHelper).ToString();
                    }
                    if (CountingSecondsForSpawnFormationHelper >= 4)
                    {
                        if (spawnFirstWaveHelper == false)
                        {
                            CountingText.gameObject.SetActive(false);

                            PositionOfSpawnFromListHelper += 1;
                            NumberOfWaves -= 1;
                            SpawnFormationBool = true;

                        }
                        else 
                        {
                            CountingText.gameObject.SetActive(false);
                            spawnFirstWaveHelper = false;

                            NumberOfWaves -= 1;
                            SpawnFormationBool = true;
                        }
                    }
                }
            }
        }
        if (SpawnFormationBool == true)
        {
            Debug.Log("SpawnNewWave");
            numberofCurrentWave += 1;

            CountingSecondsForSpawnFormationHelper = 0;

            SpawnFormationBool = false;
            string[] LoadedParameters = PlayerPrefs.GetString("LEVELCONTROLFORMATION").Split('-');

            int temp = int.Parse(LoadedParameters[PositionOfSpawnFromListHelper], CultureInfo.InvariantCulture.NumberFormat);

            SpawnEnemyShipInControlledFormation(temp, Random.Range(0, 3));

        }

        
    }
    // CALL method with numbers of first parameter 3,4,5,6,7
    void SpawnEnemyShipInControlledFormation(int NumberOfColumnsInEnemyFormation,int SpawnPositionPointer)
    {
        for (int x = 0; x <= Formation_ArrayX.Length - 1; x++) // COLUMN
        {
            for (int y = 0; y <= Formation_ArrayY.Length - 1; y++) // ROW
            {
                if (NumberOfColumnsInEnemyFormation == 3)
                {
                    if (x == 1)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 3)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 5)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }

                } // done
                else if (NumberOfColumnsInEnemyFormation == 4)
                {
                    if (x == 0)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 2)
                    {
                        //spawn formation on place 1
                        GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
                        GO_Spawn.transform.parent = this.transform;
                        GO_Spawn.transform.localPosition = new Vector3(-40.0f, -30.0f, 0.0f); // set position and animate

                        GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
                        GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(Formation_ArrayX[x], Formation_ArrayY[y], 0.0f));
                    }
                    else if (x == 4)
                    {
                        //spawn formation on place 1
                        GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
                        GO_Spawn.transform.parent = this.transform;
                        GO_Spawn.transform.localPosition = new Vector3(-40.0f, -30.0f, 0.0f); // set position and animate

                        GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
                        GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(Formation_ArrayX[x], Formation_ArrayY[y], 0.0f));
                    }
                    else if (x == 6)
                    {
                        //spawn formation on place 1
                        GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
                        GO_Spawn.transform.parent = this.transform;
                        GO_Spawn.transform.localPosition = new Vector3(-40.0f, -30.0f, 0.0f); // set position and animate

                        GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
                        GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(Formation_ArrayX[x], Formation_ArrayY[y], 0.0f));
                    }

                } //done
                else if (NumberOfColumnsInEnemyFormation == 5)
                {
                    if (x == 0)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 1)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 3)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 5)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 6)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }

                }//done
                else if (NumberOfColumnsInEnemyFormation == 6)
                {
                    if (x == 0)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 1)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 3)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 5)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 6)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }
                    else if (x == 7)
                    {
                        if (SpawnFormationFromSamePosition == true)
                        {
                            SpawnOneEnemyFromSamePosition(Formation_ArrayX[x], Formation_ArrayY[y], SpawnPositionPointer);

                        }
                        else
                        {
                            SpawnOneEnemyFromDifferentPosition(Formation_ArrayX[x], Formation_ArrayY[y]);
                        }
                    }

                }//done
                else if (NumberOfColumnsInEnemyFormation == 7)
                {

                    //spawn formation on place 1
                    GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
                    GO_Spawn.transform.parent = this.transform;
                    GO_Spawn.transform.localPosition = new Vector3(-40.0f, -30.0f, 0.0f); // set position and animate

                    GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
                    GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(Formation_ArrayX[x], Formation_ArrayY[y], 0.0f));
                    
                }//done
                else{continue;}



            }//End of for loop Y        
        }//End of for loop X
    }//End of Spawn Method

    //spawn formation on place 1
    void SpawnOneEnemyFromDifferentPosition(float FormationX,float FormationY)
    {
        int ChoosenPositionForSpawnEnemy = Random.Range(0, 4);

        if (ChoosenPositionForSpawnEnemy == 0)
        {
            GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
            GO_Spawn.transform.parent = this.transform;

            GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
            GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        }
        else if (ChoosenPositionForSpawnEnemy == 1)
        {
            GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
            GO_Spawn.transform.parent = this.transform;

            GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftBottomFormationSpawner);
            GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        }
        else if (ChoosenPositionForSpawnEnemy == 2)
        {
            GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
            GO_Spawn.transform.parent = this.transform;

            GO_Spawn.GetComponent<EnemyControl>().setstartPosition(RightUpperFormationSpawner);
            GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        }
        else if (ChoosenPositionForSpawnEnemy == 3)
        {
            GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
            GO_Spawn.transform.parent = this.transform;

            GO_Spawn.GetComponent<EnemyControl>().setstartPosition(RightBottomrFormationSpawner);
            GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        }

    }
    void SpawnOneEnemyFromSamePosition(float FormationX,float FormationY,int positionofSpawn) // positionofspawn is from 0-3 0 is left upper...
    {
        if (positionofSpawn == 0)
        {
            GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
            GO_Spawn.transform.parent = this.transform;

            GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
            GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        }
        else if (positionofSpawn == 1)
        {
            GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
            GO_Spawn.transform.parent = this.transform;

            GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftBottomFormationSpawner);
            GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        }
        else if (positionofSpawn == 2)
        {
            GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
            GO_Spawn.transform.parent = this.transform;

            GO_Spawn.GetComponent<EnemyControl>().setstartPosition(RightUpperFormationSpawner);
            GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        }
        else if (positionofSpawn == 3)
        {
            GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
            GO_Spawn.transform.parent = this.transform;

            GO_Spawn.GetComponent<EnemyControl>().setstartPosition(RightBottomrFormationSpawner);
            GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        }

    }

    // TODO - staviti gore na pocetak
    // helpers
    float timeCounter01 = 0;

    void MoveFormationLeftAndRight()
    {
        timeCounter01 += Time.deltaTime;
        float x = Mathf.Sin(timeCounter01);
        float y = 15;
        float z = 0;
        transform.position = new Vector3(x, y, z);

    }

    void MoveFormationInCircle()
    {
        timeCounter01 += Time.deltaTime;
        Debug.Log(timeCounter01);
        float x = Mathf.Cos(timeCounter01);
        float y = Mathf.Sin(timeCounter01);
        float z = 0;
        transform.position = new Vector3(x, y, z);

    }

    void MoveFormationUpAndDown()
    {
        timeCounter01 += Time.deltaTime;
        float x = 0;
        float y = Mathf.Sin(timeCounter01);
        float z = 0;
        transform.position = new Vector3(x, y, z);

    }

}// End of Class
