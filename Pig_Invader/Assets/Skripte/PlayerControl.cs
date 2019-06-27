using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    int Score;

    public int getScore()
    {
        return this.Score;
    }

    public void setScore(int value)
    {
        this.Score = value;
    }

    public Text ZivotText;

    private int ZIVOT;

    // Start is called before the first frame update
    void Start()
    {
        ZivotText.text = "X 3";
        ZIVOT = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name.Contains("beef"))
        {
            Destroy(collision.gameObject);

            ZIVOT += 1;

            ZivotText.text = "X " + ZIVOT.ToString();

            Debug.Log(ZIVOT);
        }
        if (collision.transform.name.Contains("govno"))
        {
            if (ZIVOT == 1)
            {
                Destroy(collision.gameObject);
                Application.LoadLevel("GameOver");
            }
            else
            {
                Destroy(collision.gameObject);

                ZIVOT -= 1;

                ZivotText.text = "X " + ZIVOT.ToString();

                Debug.Log(ZIVOT);
            }
        }

    }


}
