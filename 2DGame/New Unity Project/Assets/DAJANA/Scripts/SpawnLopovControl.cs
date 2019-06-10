using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLopovControl : MonoBehaviour {

    public GameObject LOPOV;

    float vrijeme;

    float xmin;
    float xmax;

    int spawndelay;

    // Use this for initialization
    void Start () {
        spawndelay = 17;

        vrijeme = 0.0f;

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjelijevo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 krajnjedesno = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = krajnjelijevo.x;
        xmax = krajnjedesno.x;
    }
	
	// Update is called once per frame
	void Update () {

        vrijeme += Time.deltaTime;

        if (vrijeme > spawndelay)
        {
            vrijeme = 0.0f;

            if (spawndelay != 1)
            {
                spawndelay -= 4;
            }

            float RandomPozicijax = Random.Range(xmin, xmax);

            Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

            Instantiate(LOPOV, vec, Quaternion.identity);

        }


    }



}
