using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeChecker : MonoBehaviour
{
    // 
    public GameObject HeadSnake;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // uzimanje pozicije tijela i provjeravanje gdje se nalazi na screen-u
        Vector3 pos = Camera.main.WorldToViewportPoint(HeadSnake.transform.position);

        // TODO - napraviti umiranje za lijevo i desno
        if (pos.x < 0.0)
        {
            Debug.Log("LIJEVO");
        }
        if (1.0 < pos.x)
        {
            Debug.Log("DESNO");
        }
        if (pos.y < 0.0)
        {
            Debug.Log("ISPOD");
        }
        if (1.0 < pos.y)
        {
            Debug.Log("IZNAD");
        }

    }//update




}
