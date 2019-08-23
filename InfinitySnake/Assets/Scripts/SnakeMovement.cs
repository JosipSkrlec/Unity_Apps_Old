using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float BrzinaKretanja = 2.0f;
    public float BrzinaRotiranja = 20.0f;

    public List<Transform> bodyParts = new List<Transform>();

    public GameObject tijelo01;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position += transform.up * BrzinaKretanja * Time.deltaTime;


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * BrzinaRotiranja * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * BrzinaRotiranja * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("jabuka"))
        {
            GameObject g =  Instantiate(tijelo01);

            g.GetComponent<SnakeBodyPart>().head = bodyParts[bodyParts.Count -1];


            bodyParts.Add(g.transform);



            Debug.Log(bodyParts.Count);



            Destroy(collision.gameObject);
        }
    }




}
