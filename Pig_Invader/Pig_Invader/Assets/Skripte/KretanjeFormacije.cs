using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KretanjeFormacije : MonoBehaviour
{

    public float moveSpeed = 0.5f;

    float xmin;
    float xmax;

    bool check = false;

    float vrijeme2 = 2.0f;

    float vrijeme = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjelijevo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 krajnjedesno = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = krajnjelijevo.x;
        xmax = krajnjedesno.x;

        Debug.Log(xmin + " " + xmax);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pozicija = this.transform.position;

        vrijeme += Time.deltaTime;

        if (vrijeme >= vrijeme2)
        {
            if (check == true)
            {
                check = false;

                vrijeme = 0.0f;
            }
            else if (check == false)
            {
                check = true;

                vrijeme2 = 4.0f;

                vrijeme = 0.0f;
            }

        }

        if (check == true)
        {
            this.transform.position = new Vector3(pozicija.x - moveSpeed * Time.deltaTime, pozicija.y, pozicija.z);
        }
        else
        {
            this.transform.position = new Vector3(pozicija.x + moveSpeed * Time.deltaTime, pozicija.y, pozicija.z);
        }

    }
}
