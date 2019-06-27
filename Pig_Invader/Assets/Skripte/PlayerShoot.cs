using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Player;

    public GameObject Bullet1;

    float vrijeme = 0.0f;
    bool pucajcheck = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vrijeme += Time.deltaTime;

        if (vrijeme >= 0.3f)
        {
            pucajcheck = true;
        }
        
    }

    public void Pucaj()
    {
        if (pucajcheck == true && vrijeme >= 0.3f)
        {
            Vector3 pozicijaplayer = new Vector3(Player.transform.position.x, Player.transform.position.y + 0.5f, Player.transform.position.z);

            Instantiate(Bullet1, pozicijaplayer, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));

            vrijeme = 0.0f;

        }
        else
        {
            Debug.Log("cooldown");
        }

    }




}
