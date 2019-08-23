using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject jab;

    // Use this for initialization
    void Start()
    {


        spawnaj();

    }

    void spawnaj()
    {
        // spawn random u screen size (RESPONZIVNO JE)
        for (int a = 0; a <= 5; a++)
        {
            float x = Random.Range(0.05f, 0.95f);
            float y = Random.Range(0.05f, 0.95f);
            Vector3 pos = new Vector3(x, y, 10.0f);
            pos = Camera.main.ViewportToWorldPoint(pos);

            Instantiate(jab, pos, Quaternion.identity);
        }
    }


    private void Update()
    {
       
    }


}
