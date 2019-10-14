using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour {

    // "dobri objekti"
    public GameObject Objekt1;
    public GameObject Objekt2;
    public GameObject Objekt3;
    public GameObject Objekt4;
    public GameObject Objekt5;
    public GameObject Objekt6;
    public GameObject Objekt7;
    public GameObject Objekt8;
    public GameObject Objekt9;


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
            int temp = Random.Range(1,12);

            if (temp == 1)
            {
                float RandomPozicijax = Random.Range(xmin,xmax);

                Vector3 vec = new Vector3(RandomPozicijax,6.0f, 0.0f);

                Instantiate(Objekt1, vec, Quaternion.identity);
            }
            else if (temp == 2)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt2, vec, Quaternion.identity);
            }
            else if(temp == 3)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt3, vec, Quaternion.identity);
            }
            else if(temp == 4)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt4, vec, Quaternion.identity);
            }
            else if(temp == 5)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt5, vec, Quaternion.identity);
            }
            else if(temp == 6)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt6, vec, Quaternion.identity);
            }
            else if(temp == 7)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt7, vec, Quaternion.identity);
            }
            else if(temp == 8)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt8, vec, Quaternion.identity);
            }
            else if(temp == 9)
            {
                float RandomPozicijax = Random.Range(xmin, xmax);

                Vector3 vec = new Vector3(RandomPozicijax, 6.0f, 0.0f);

                Instantiate(Objekt9, vec, Quaternion.identity);
            }


            vrijeme = 0.0f;

        }
        




	}





}
