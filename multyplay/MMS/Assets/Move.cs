using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Move the object upward in world space 1 unit/second.
            transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Move the object upward in world space 1 unit/second.
            transform.Translate(-Vector3.up * Time.deltaTime, Space.World);
        }


    }




}
