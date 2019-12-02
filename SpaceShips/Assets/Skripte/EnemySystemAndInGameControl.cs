using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystemAndInGameControl : MonoBehaviour
{
    private protected  float[] Formation_ArrayX = new float[] { 14.0f, 9.2f, 4.6f, 0.0f, -4.6f, -9.2f, -14.0f }; // 7 numbers
    private protected float[] Formation_ArrayY = new float[] { -28.0f, -24.0f, -20.0f, -16.0f, -12.0f, -8.0f, -4.0f, 0.0f }; // 8 numbers

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

    public float cooldown = 5.0f;

    float time;

    // spawn first wave
    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        int TypeOfEnemyShip = 0;
        for (int x = 0; x <= 6; x++)
        {
            TypeOfEnemyShip = Random.Range(1, 4);
            for (int y = 0; y <= 7; y++)
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

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= cooldown)
        {
            time = 0.0f;

            int NumberOfChields = this.gameObject.transform.childCount;

            int RandomChoosenEnemyForShoot = Random.Range(0,NumberOfChields);

            this.gameObject.transform.GetChild(RandomChoosenEnemyForShoot).GetComponent<EnemyControl>().setShootEnabled(true);

        }

        
    }




}
