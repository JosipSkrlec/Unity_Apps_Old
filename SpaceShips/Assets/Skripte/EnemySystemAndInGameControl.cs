using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystemAndInGameControl : MonoBehaviour
{
    // TODO - napraviti punjenje u startu tj. awake-u i broj koji ce biti 0 ne spawna se stupac
    private protected  float[] Formation_ArrayX = new float[] { 14.0f, 9.2f, 4.6f, 0.0f, -4.6f, -9.2f, -14.0f }; // 7 numbers //COLUMN
    private protected float[] Formation_ArrayY = new float[] { -28.0f, -24.0f, -20.0f, -16.0f, -12.0f, -8.0f, -4.0f}; // 8 numbers // ROW

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

    private Vector3 LeftUpperFormationSpawner = new Vector3(60.0f, -30.0f, 0.0f);
    private Vector3 LeftBottomFormationSpawner = new Vector3(40.0f, 0.0f, 0.0f);
    private Vector3 RightUpperFormationSpawner = new Vector3(-60.0f, -30.0f, 0.0f);
    private Vector3 RightBottomrFormationSpawner = new Vector3(-40.0f, 0.0f, 0.0f);

    [Header("Game System Control")]

    // Variable is for number of enemy to reload formation and spawn another one
    private int NumberOfEnemyForDie = 0; // tu pohranjujemo broj spawnanih enemya, kada dode do 0 ili manje tada se pokrece sljedeca formacija
         

    public int NumberOfWaves = 0;
    public int getNumberOfWaves() { return this.NumberOfWaves; }
    public void setNumberOfWaves(int value) { this.NumberOfWaves = value; }

    public float cooldownforShooting = 5.0f;
    public float getcooldownforShooting() { return this.cooldownforShooting; }
    public void setcooldownforShooting(float value) { this.cooldownforShooting = value; }

    private int NumberOfColumnInFormation = 0;

    bool SpawnFormationBool = true;
    bool SpawnFormationFromSamePosition = true;


    // HELPERS
    float time;

    // spawn first wave
    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {       


    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= cooldownforShooting)
        {
            time = 0.0f;

            int NumberOfChields = this.gameObject.transform.childCount;

            int RandomChoosenEnemyForShoot = Random.Range(0,NumberOfChields);

            try
            {
                this.gameObject.transform.GetChild(RandomChoosenEnemyForShoot).GetComponent<EnemyControl>().setShootEnabled(true);
            }
            catch (System.Exception e) { };

           

        }

        // TODO - remove that if and replace with dynamic one
        // spawn again when child = 0 or less then 0
        if (this.transform.childCount <= 0)
        {
            SpawnFormationBool = true;
        }

        if (SpawnFormationBool == true)
        {
            SpawnFormationBool = false;
            // DELETE THAT *for playable(
            int b = Random.Range(0,2);

            if (b == 0)
            {
                SpawnFormationFromSamePosition = true;
            }
            else
            {
                SpawnFormationFromSamePosition = false;
            }

            int c = Random.Range(3, 8);
            int d = Random.Range(0,4);

            SpawnEnemyShipInControlledFormation(c, d);


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

}// End of Class
