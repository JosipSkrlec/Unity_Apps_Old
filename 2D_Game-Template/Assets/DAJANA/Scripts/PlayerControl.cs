using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public Text Rezultat;
    public GameObject LosaEksplozija;

    public Text Zivot;

    int zivot = 5;
    public static int rezz = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("1EUR"))
        {
            rezz += 1;
            Rezultat.text = rezz.ToString() + "€";

            Destroy(collision.gameObject);

        }
        else if (collision.transform.name.Contains("2EUR"))
        {
            rezz += 2;
            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);

        }
        else if (collision.transform.name.Contains("5EUR"))
        {
            rezz += 5;
            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);

        }
        else if (collision.transform.name.Contains("10EUR"))
        {
            rezz += 10;
            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);

        }
        else if (collision.transform.name.Contains("20EUR"))
        {
            rezz += 20;
            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);

        }
        else if (collision.transform.name.Contains("50EUR"))
        {
            rezz += 50;
            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);

        }
        else if (collision.transform.name.Contains("100EUR"))
        {
            rezz += 100;
            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);

        }
        else if (collision.transform.name.Contains("200EUR"))
        {
            rezz += 200;
            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);

        }
        else if (collision.transform.name.Contains("500EUR"))
        {
            rezz += 500;
            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);


        }

        else if (collision.transform.name.Contains("lopov"))
        {
            int temp = Random.Range(1, 1000);

            rezz -= temp;

            Rezultat.text = rezz.ToString() + " €";

            Destroy(collision.gameObject);

            zivot -= 1;

            if (zivot == 0)
            {
                SceneManager.LoadScene("GameOver");
            }

            Zivot.text = "X " + zivot.ToString();

            Instantiate(LosaEksplozija, this.gameObject.transform.position, Quaternion.identity);
        }


    }




}
