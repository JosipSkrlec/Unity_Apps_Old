﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject jab;

    public GameObject test01;
    public GameObject test02;


    // Use this for initialization
    void Start()
    {


        spawnaj();

    }


    private void Update()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        test02.transform.localScale = new Vector3((height / 4f) , 0.25f,0.25f);

        Vector3 pos = new Vector3(0.25f, 0.0f, 0.0f);
        pos = Camera.main.ViewportToWorldPoint(pos);

        Instantiate(test02, pos, Quaternion.identity);

        //float x = Random.Range(0.05f, 0.95f);
        //float y = Random.Range(0.05f, 0.95f);
        //Vector3 pos = new Vector3(x, y, 10.0f);
        //pos = Camera.main.ViewportToWorldPoint(pos);

        //Instantiate(jab, pos, Quaternion.identity);

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



}


// PRVA SCENA SAMPLE SCENA
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class test : MonoBehaviour
//{
//    public GameObject jab;

//    public GameObject test01;

//    // Use this for initialization
//    void Start()
//    {


//        spawnaj();

//    }

//    void spawnaj()
//    {
//        // spawn random u screen size (RESPONZIVNO JE)
//        for (int a = 0; a <= 5; a++)
//        {
//            float x = Random.Range(0.05f, 0.95f);
//            float y = Random.Range(0.05f, 0.95f);
//            Vector3 pos = new Vector3(x, y, 10.0f);
//            pos = Camera.main.ViewportToWorldPoint(pos);

//            Instantiate(jab, pos, Quaternion.identity);
//        }

//        Vector3 pos1 = new Vector3(0f, 0.5f, 10.0f);
//        pos1 = Camera.main.ViewportToWorldPoint(pos1);
//        Instantiate(test01, pos1, Quaternion.identity);

//        Vector3 pos2 = new Vector3(1f, 0.5f, 10.0f);
//        pos2 = Camera.main.ViewportToWorldPoint(pos2);
//        Instantiate(test01, pos2, Quaternion.identity);

//    }


//    private void Update()
//    {

//    }


//}
