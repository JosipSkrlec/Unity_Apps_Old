using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControl : MonoBehaviour
{
    public GameObject Enemy;

    private int BrojUbijenih = 0;

    public int getBrojUbijenih()
    {
        return this.BrojUbijenih;
    }

    public void setBrojUbijenih(int value)
    {
        this.BrojUbijenih += value;
    }

    bool jednomprvi = false;
    bool jednomdrugi = false;
    bool jednomtreci = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject g = Instantiate(Enemy, this.gameObject.transform);
        g.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (BrojUbijenih == 1 &&  jednomprvi == false)
        {
            //Instantiate(Enemy,new Vector3(-1.0f,0.0f,0.0f),Quaternion.identity);
            //Instantiate(Enemy, new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);

            jednomprvi = true;

            GameObject g = Instantiate(Enemy, this.gameObject.transform);
            g.transform.localPosition = new Vector3(-1.0f, 0.0f, 0.0f);

            GameObject g1 = Instantiate(Enemy, this.gameObject.transform);            
            g1.transform.localPosition = new Vector3(1.0f, 0.0f, 0.0f);

        }

        if (BrojUbijenih == 3 && jednomdrugi == false)
        {
            //Instantiate(Enemy,new Vector3(-1.0f,0.0f,0.0f),Quaternion.identity);
            //Instantiate(Enemy, new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);

            jednomdrugi = true;

            GameObject g = Instantiate(Enemy, this.gameObject.transform);
            g.transform.localPosition = new Vector3(-2.0f, -0.8f, 0.0f);

            GameObject g1 = Instantiate(Enemy, this.gameObject.transform);
            g1.transform.localPosition = new Vector3(-1.0f, 0.0f, 0.0f);

            GameObject g2 = Instantiate(Enemy, this.gameObject.transform);
            g2.transform.localPosition = new Vector3(1.0f, 0.0f, 0.0f);

            GameObject g3 = Instantiate(Enemy, this.gameObject.transform);
            g3.transform.localPosition = new Vector3(2.0f, -0.8f, 0.0f);

        }

        if (BrojUbijenih == 7 && jednomtreci == false)
        {
            jednomtreci = true;

            GameObject g = Instantiate(Enemy, this.gameObject.transform);
            g.transform.localPosition = new Vector3(-2.5f, -1.3f, 0.0f);

            GameObject g1 = Instantiate(Enemy, this.gameObject.transform);
            g1.transform.localPosition = new Vector3(-0.7f, -1.3f, 0.0f);

            GameObject g2 = Instantiate(Enemy, this.gameObject.transform);
            g2.transform.localPosition = new Vector3(2.5f, -1.3f, 0.0f);

            GameObject g3 = Instantiate(Enemy, this.gameObject.transform);
            g3.transform.localPosition = new Vector3(0.7f, -1.3f, 0.0f);

            GameObject g4 = Instantiate(Enemy, this.gameObject.transform);
            g4.transform.localPosition = new Vector3(-2.5f, 0.0f, 0.0f);

            GameObject g5 = Instantiate(Enemy, this.gameObject.transform);
            g5.transform.localPosition = new Vector3(-0.7f, 0.0f, 0.0f);

            GameObject g6 = Instantiate(Enemy, this.gameObject.transform);
            g6.transform.localPosition = new Vector3(2.5f, 0.0f, 0.0f);

            GameObject g7 = Instantiate(Enemy, this.gameObject.transform);
            g7.transform.localPosition = new Vector3(0.7f, 0.0f, 0.0f);


        }

    }




}
