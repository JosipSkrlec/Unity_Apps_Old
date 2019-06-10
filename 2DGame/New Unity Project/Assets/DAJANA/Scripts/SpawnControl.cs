using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {

    public GameObject Objekt1;
    public GameObject Objekt2;

    float vrijeme;

    float xmin;
    float xmax;


    // Use this for initialization
    void Start () {
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

        if (vrijeme >= 1.0f)
        {
            int temp = Random.Range(1,3);

            if (temp == 1)
            {
                float RandomPozicijax = Random.Range(xmin,xmax);

                Vector3 vec = new Vector3(RandomPozicijax,6.0f, 0.0f);

                Instantiate(Objekt1, vec, Quaternion.identity);
            }
            if (temp == 2)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt2, vec, Quaternion.identity);
            }

            vrijeme = 0.0f;

        }
        




	}





}
