using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject jab;

    public GameObject CrvenaVrata;
    public GameObject LjubicastaVrata;
    public GameObject ZelenaVrata;


    float vrijeme = 0.0f;

    float pozicijavratay = 0.0f;

    // Use this for initialization
    void Start()
    {
        spawnajJabuke();

        spawnajprolaze();

    }


    void Update()
    {
        vrijeme += Time.deltaTime;

        if (vrijeme >= 2.0f)
        {
            vrijeme = 0.0f;

            spawnajprolaze();


        }


    }

    void spawnajJabuke()
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

    // TODO- DODATI RANDOM BOJE
    void spawnajprolaze()
    {
        // varijable za spawn
        float height = Camera.main.orthographicSize * 2;
        float width = height * Screen.width / Screen.height;

        // 3.0f je kolicina na koliko djelova zelimo podjeliti screen
        CrvenaVrata.transform.localScale = new Vector3((width / 3.0f), 0.25f, 0.25f);

        pozicijavratay += 0.50f;
        // POZICIJA SPAWNANJA
        // 0.0f je skroz desno, 0.5f je u sredini i 1.0f je skroz desno
        Vector3 pos = new Vector3(0.15f, pozicijavratay, 0.0f); // umjesto pozicijavratay je 0.0f pocetno
        pos = Camera.main.ViewportToWorldPoint(pos);

        Instantiate(CrvenaVrata, new Vector3(pos.x, pos.y, 1.0f), Quaternion.identity);

        Vector3 pos1 = new Vector3(0.5f, pozicijavratay, 0.0f);
        pos1 = Camera.main.ViewportToWorldPoint(pos1);

        Instantiate(CrvenaVrata, new Vector3(pos1.x, pos.y, 1.0f), Quaternion.identity);

        Vector3 pos2 = new Vector3(0.85f, pozicijavratay, 0.0f);
        pos2 = Camera.main.ViewportToWorldPoint(pos2);

        Instantiate(CrvenaVrata, new Vector3(pos2.x, pos.y, 1.0f), Quaternion.identity);
        
    }



}