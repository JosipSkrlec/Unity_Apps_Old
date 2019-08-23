using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject jab;

    // Set this to the in-world distance between the left & right edges of your scene.
    public float sceneWidth = 10;

    // Use this for initialization
    void Start()
    {
        //float unitsPerPixel = sceneWidth / Screen.width;

        //float unitsPerPixell = Screen.width / Screen.height;

        //Debug.Log("units per pixell " + unitsPerPixell);

        //float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        //GetComponent<Camera>().orthographicSize = desiredHalfHeight;

        //Debug.Log(desiredHalfHeight);

    }


    private void Update()
    {
        float width = Screen.width;
        float height = Screen.height;


        float rez = width / height;

        Debug.Log("w = " + width + " h = " + height + " r = " + rez);

        float height1 = Camera.main.orthographicSize * 2;
        float width1 = height * Screen.width / Screen.height;


        //
        //Vector3 vec = new Vector3(width1, width1, 1.0f);
        //vec = Camera.main.ViewportToWorldPoint(vec);

        float x = Random.Range(0.05f, 0.95f);
        float y = Random.Range(0.05f, 0.95f);
        Vector3 pos = new Vector3(x, y, 10.0f);
        pos = Camera.main.ViewportToWorldPoint(pos);

        Instantiate(jab, pos, Quaternion.identity);


        //Vector3 pos = new Vector3(Random.value, Random.value, distFromCamera);
        //pos = Camera.main.ViewportToWorldPoint(pos);

        //Instantiate(prefab, pos, Quaternion.identity);
        // PROVJERITI
        // https://answers.unity.com/questions/774085/random-spawn-objects-within-the-screen-width-and-h.html
    }


}
