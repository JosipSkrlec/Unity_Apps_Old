using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region Game Cotrol Variables
    // PLAYER VARIABLES
    public float PlayerShootingCooldown;

    private protected int NumberOfWaves;

    #endregion

    #region Main Objects
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

        if (time >= PlayerShootingCooldown)
        {
            Vector3 PositionOfPlayer = this.gameObject.transform.position;


            // TODO - napraviti system upgrade-a i razlicitog pucanja

            GameObject GO_ForSpawn = (GameObject)Instantiate(Projectile01);
            GO_ForSpawn.transform.position = new Vector3(PositionOfPlayer.x, PositionOfPlayer.y + 0.5f, PositionOfPlayer.z);
            GO_ForSpawn.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            time = 0.0f;
        }

        
    }



}
