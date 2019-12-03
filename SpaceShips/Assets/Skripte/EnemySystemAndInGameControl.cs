using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystemAndInGameControl : MonoBehaviour
{
    // TODO - napraviti punjenje u startu tj. awake-u i broj koji ce biti 0 ne spawna se stupac
    private protected  float[] Formation_ArrayX = new float[] { 14.0f, 9.2f, 4.6f, 0.0f, -4.6f, -9.2f, -14.0f }; // 7 numbers
    private protected float[] Formation_ArrayY = new float[] { -28.0f, -24.0f, -20.0f, -16.0f, -12.0f, -8.0f, -4.0f}; // 8 numbers

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

    [Header("")]
    public int NumberOfWaves = 3;

    public float cooldownforShooting = 5.0f;
    public float getcooldownforShooting() { return this.cooldownforShooting; }
    public void setcooldownforShooting(float value) { this.cooldownforShooting = value; }

    bool spawnOnce = true;


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

            this.gameObject.transform.GetChild(RandomChoosenEnemyForShoot).GetComponent<EnemyControl>().setShootEnabled(true);

        }

        if (this.transform.childCount <= 0)
        {
            spawnOnce = true;
        }

        if (spawnOnce == true)
        {
            spawnOnce = false;
            Spawn();
        }

        
    }

    void Spawn()
    {
        int TypeOfEnemyShip = 0;
        for (int x = 0; x <= Formation_ArrayX.Length - 1; x++)
        {
            TypeOfEnemyShip = Random.Range(1, 4);
            for (int y = 0; y <= Formation_ArrayY.Length - 1; y++)
            {
                if (TypeOfEnemyShip == 1)
                {
                    GameObject GO_Spawn = Instantiate(ResistanceEnemyShip01);
                    GO_Spawn.transform.parent = this.transform;
                    GO_Spawn.transform.localPosition = new Vector3(-40.0f, -30.0f, 0.0f); // set position and animate

                    GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftUpperFormationSpawner);
                    GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(Formation_ArrayX[x], Formation_ArrayY[y], 0.0f));
                }
                else if (TypeOfEnemyShip == 2)
                {
                    GameObject GO_Spawn = Instantiate(ResistanceEnemyShip02);
                    GO_Spawn.transform.parent = this.transform;

                    GO_Spawn.GetComponent<EnemyControl>().setstartPosition(LeftBottomFormationSpawner);
                    GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(Formation_ArrayX[x], Formation_ArrayY[y], 0.0f));

                }
                else if (TypeOfEnemyShip == 3)
                {
                    GameObject GO_Spawn = Instantiate(ResistanceEnemyShip03);
                    GO_Spawn.transform.parent = this.transform;

                    GO_Spawn.GetComponent<EnemyControl>().setstartPosition(RightUpperFormationSpawner);
                    GO_Spawn.GetComponent<EnemyControl>().settargetPosition(new Vector3(Formation_ArrayX[x], Formation_ArrayY[y], 0.0f));
                }
                else
                {
                    Debug.Log("Something went wrong!");
                }

            }
        }
    }



}
