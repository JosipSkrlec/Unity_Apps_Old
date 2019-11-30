using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    #region Game Cotrol Variables
    public float Cooldown;


    private protected int NumberOfWaves;

    #endregion

    #region Main Objects
    [Header("Enemy Ships / Alliance")]
    public GameObject AllianceEnemyShip01;
    public GameObject AllianceEnemyShip02;
    public GameObject AllianceEnemyShip03;

    [Header("Enemy Ships / Resistance")]
    public GameObject ResistanceEnemyShip01;
    public GameObject ResistanceEnemyShip02;
    public GameObject ResistanceEnemyShip03;

    [Header("Projectiles")]
    public GameObject Projectile01;
    public GameObject Projectile02;

    #endregion

    #region Help Variables
    private float time;

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= Cooldown)
        {
            Vector3 PositionOfPlayer = this.gameObject.transform.position;

            Debug.Log(PositionOfPlayer + " " + this.gameObject.transform.localPosition);

            Instantiate(Projectile01,new Vector3(PositionOfPlayer.x, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z), Quaternion.identity);

            time = 0.0f;
        }

        
    }



}
