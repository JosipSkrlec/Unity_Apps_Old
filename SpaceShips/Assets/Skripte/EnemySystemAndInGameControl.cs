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
    [Header("Player GO")]
    public GameObject PLAYER;

    [Header("Enemy Ships / Resistance")]
    private GameObject EnemyShip;

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

    private int DropChance = 0;
    private int EnemyHealth = 0;

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

    [Header("GUI INFO")]
    public Text EnemyHealthGUI;

    //private protected List<string> ListToStoreGameLevelControl = new List<string>();
    //private protected string SaveHelper;

    private protected List<int> NumberInFormation = new List<int>();
    private int PositionOfSpawnFromListHelper = 0;
    
    // HELPERS
    bool SpawnFormationBool = false;
    float TimeForShooting;
    float TimeForCountThreeSeconds;
    int numberOfTotalWaves;
    bool spawnFirstWaveHelper = true;
    int numberofCurrentWave = 1;
    // OVO JE ZA KRATANJE METODE KOJE SE NALAZE NA DNU
    float timeCounter01 = 0;

    // u awake se priprema za start i update , ucitavaju se parametri broj wave-ova enemycooldown i spawnenemyrendom
    // ucitava se i dropchance
    private void Awake()
    {
        // biranje izgleda enemy-a
        int EnemyShipRandomChose = Random.Range(1,4);

        if (EnemyShipRandomChose == 1)
        {
            EnemyShip = ResistanceEnemyShip01;
        }
        else if (EnemyShipRandomChose == 2)
        {

            EnemyShip = ResistanceEnemyShip02;
        }
        else if (EnemyShipRandomChose == 3)
        {

            EnemyShip = ResistanceEnemyShip03;
        }

        Time.timeScale = 1.0f;

        try
        {
            int NumberOfEnemyWaves = PlayerPrefs.GetInt("NumberOfEnemyWaves");
            float EnemyAttackCooldown = PlayerPrefs.GetFloat("EnemyAttackCooldown");

            EnemyHealth = PlayerPrefs.GetInt("EnemyHealth");
            DropChance = PlayerPrefs.GetInt("DropChance");

            if (DropChance == 0)
            {
                PlayerPrefs.SetInt("DropChance",10);
            }

            numberOfTotalWaves = NumberOfEnemyWaves;
            NumberOfWaves = NumberOfEnemyWaves; // -1 zbog array counter-a
            cooldownforShooting = EnemyAttackCooldown;

#pragma warning disable CS0168 // Variable is declared but never used
        }
        catch (System.Exception e) { }
#pragma warning restore CS0168 // Variable is declared but never used

    }

    // postavljanje movement-a random
    void Start()
    {

        ShowInfoOnGUI();

        //int EnemyMovement = Random.Range(1,4);

        //if (EnemyMovement == 1)
        //{
        //    MoveFormationLeftAndRightBool = true;
        //}
        //else if (EnemyMovement == 2)
        //{
        //    MoveFormationInCircleBool = true;
        //}
        //else
        //{
        //    MoveFormationUpAndDOwnBool = true;
        //}
    }

    // enemy shooting trigger

    void Update()
    {
        TimeForShooting += Time.deltaTime;

        // kretanje random stavljano u START() metodi
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

        // pucanje, pronalazi se random child i on puca sa odredenim cooldown-om
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
        } 

        // provjera da li je children 0ili manji u glavnom objektu za spawn, pocetno je tamo jedan objekt koji se destroy-a nakon 2 sec
        // te pocinje pravi spawn,
        if (this.transform.childCount <= 0)
        {
            if (NumberOfWaves <= 0)
            {
                SpawnFormationBool = false;

                Time.timeScale = 0.0f;

                PLAYER.GetComponent<PlayerControl>().setplayUpdate(false);

                // campaignlvlcompleted
                int currentplayedlvl = PlayerPrefs.GetInt("CurrentCampaignLVL");

                if (currentplayedlvl != 0)
                {
                    PlayerPrefs.SetInt("CampaignFinished", currentplayedlvl);
                }

                int CurrentMoonstonesReward = PlayerPrefs.GetInt("MoonstonesReward");

                MoonstonesRewardText.text = CurrentMoonstonesReward.ToString();

                WinPanel.SetActive(true);                

            }
            // ako ima jos wave-ova za spawn tada se prikazuje text broja trenutnog i max wave-a
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
                        // spawn-a se prvi wave
                        if (spawnFirstWaveHelper == false)
                        {
                            CountingText.gameObject.SetActive(false);

                            PositionOfSpawnFromListHelper += 1;
                            NumberOfWaves -= 1;
                            SpawnFormationBool = true;

                        }
                        // trigera se za spawn
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

        // to se trigger-a u linijama u else iznad
        if (SpawnFormationBool == true)
        {
            // za movement
            int EnemyMovement = Random.Range(1, 4);
            Debug.Log("spawn again" + EnemyMovement);
            if (EnemyMovement == 1)
            {
                MoveFormationLeftAndRightBool = true;
            }
            else if (EnemyMovement == 2)
            {
                MoveFormationInCircleBool = true;
            }
            else
            {
                MoveFormationUpAndDOwnBool = true;
            }

            numberofCurrentWave += 1;

            CountingSecondsForSpawnFormationHelper = 0;

            SpawnFormationBool = false;
            string[] LoadedParameters = PlayerPrefs.GetString("LEVELCONTROLFORMATION").Split('-');

            int numberOfFormationColumn = int.Parse(LoadedParameters[PositionOfSpawnFromListHelper], CultureInfo.InvariantCulture.NumberFormat);

            SpawnEnemyShipInControlledFormation(numberOfFormationColumn);

        }
        
    }

    // tu se smao poziva metoda za spawn SpawnEnemyHelper
    // poziva se metoda koja spawn-a enemy-e sa parametrom broj stupova formacije 3,4,5,6,7 i spawn pos pointer sa koje pozicije spawn-a
    void SpawnEnemyShipInControlledFormation(int NumberOfColumnsInEnemyFormation)
    {
        // COLUMN
        for (int x = 0; x <= Formation_ArrayX.Length - 1; x++) // COLUMN
        {
            // ROW
            for (int y = 0; y <= Formation_ArrayY.Length - 1; y++) // ROW
            {
                if (NumberOfColumnsInEnemyFormation == 3)
                {
                    if (x == 1)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 3)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 5)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }

                } // done
                else if (NumberOfColumnsInEnemyFormation == 4)
                {
                    if (x == 0)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 2)
                    {
                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                    }
                    else if (x == 4)
                    {
                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                    }
                    else if (x == 6)
                    {
                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                    }

                } //done
                else if (NumberOfColumnsInEnemyFormation == 5)
                {
                    if (x == 0)
                    {
  
                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 1)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 3)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 5)
                    {
    
                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 6)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }

                }//done
                else if (NumberOfColumnsInEnemyFormation == 6)
                {
                    if (x == 0)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 1)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 3)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 5)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 6)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);
                        
                    }
                    else if (x == 7)
                    {
                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }

                }//done
                else if (NumberOfColumnsInEnemyFormation == 7)
                {

                    if (x == 0)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 1)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 2)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 3)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 4)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 5)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 6)
                    {

                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }
                    else if (x == 7)
                    {
                        SpawnEnemyHelper(Formation_ArrayX[x], Formation_ArrayY[y]);

                    }

                }//done

                else{continue;}
            }//End of for loop Y        
        }//End of for loop X
    }//End of Spawn Method

    //KORISTI se kao helper u SpawnEnemyShipInControlledFormation
    void SpawnEnemyHelper(float FormationX,float FormationY)
    {
        GameObject GO_Spawn = Instantiate(EnemyShip,transform.position, transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        GO_Spawn.transform.parent = this.transform;

        GO_Spawn.GetComponent<EnemyControl>().setHealth(EnemyHealth);
        GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
        GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
        GO_Spawn.GetComponent<EnemyControl>().setDropChance(DropChance);

        //// random number iz pozicije od 1-4 (pogledati u editor-u)
        //int ChoosenPositionForSpawnEnemy = Random.Range(0, 4);

        //if (ChoosenPositionForSpawnEnemy == 0)
        //{


        //}
        //else if (ChoosenPositionForSpawnEnemy == 1)
        //{
        //    GameObject GO_Spawn = Instantiate(EnemyShip);
        //    GO_Spawn.transform.parent = this.transform;

        //    GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftBottomFormationSpawner);
        //    GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));

        //    GO_Spawn.GetComponent<EnemyControl>().setDropChance(DropChance);
        //}
        //else if (ChoosenPositionForSpawnEnemy == 2)
        //{
        //    GameObject GO_Spawn = Instantiate(EnemyShip);
        //    GO_Spawn.transform.parent = this.transform;

        //    GO_Spawn.GetComponent<EnemyControl>().setstartPosition(RightUpperFormationSpawner);
        //    GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));

        //    GO_Spawn.GetComponent<EnemyControl>().setDropChance(DropChance);
        //}
        //else if (ChoosenPositionForSpawnEnemy == 3)
        //{
        //    GameObject GO_Spawn = Instantiate(EnemyShip);
        //    GO_Spawn.transform.parent = this.transform;

        //    GO_Spawn.GetComponent<EnemyControl>().setstartPosition(RightBottomrFormationSpawner);
        //    GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));

        //    GO_Spawn.GetComponent<EnemyControl>().setDropChance(DropChance);
        //}

    }   


    //GameObject GO_Spawn = Instantiate(EnemyShip);
    //GO_Spawn.transform.parent = this.transform;

    //        GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
    //GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(FormationX, FormationY, 0.0f));
            
    //        // drop chance
    //        GO_Spawn.GetComponent<EnemyControl>().setDropChance(DropChance);



    // MOVEMENT
    void MoveFormationLeftAndRight()
    {
        timeCounter01 += Time.deltaTime;
        float x = Mathf.Sin(timeCounter01);
        float y = 15;
        float z = 0;
        transform.position = new Vector3(x, y, z);

    }
    // MOVEMENT
    void MoveFormationInCircle()
    {
        timeCounter01 += Time.deltaTime;
        float x = Mathf.Cos(timeCounter01);
        float y = Mathf.Sin(timeCounter01)+15;
        float z = 0;
        transform.position = new Vector3(x, y, z);

    }
    // MOVEMENT
    void MoveFormationUpAndDown()
    {
        timeCounter01 += Time.deltaTime;
        float x = 0;
        float y = Mathf.Sin(timeCounter01)+15;
        float z = 0;
        transform.position = new Vector3(x, y, z);

    }

    void ShowInfoOnGUI()
    {
        EnemyHealth = PlayerPrefs.GetInt("EnemyHealth");

        EnemyHealthGUI.text = EnemyHealth.ToString();

    }

}// End of Class
