using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour
{
    public int Zivot = 2;

    public GameObject MalaEksplozija;
    public GameObject VelikaEksplozija;

    public GameObject beef;
    public GameObject EnemyBullet;

    float vrijeme = 0.0f;

    int randomvrijeme = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vrijeme += Time.deltaTime;

        if (vrijeme >= randomvrijeme)
        {
            int randomtempo0 = Random.RandomRange(0, 2);

            if (randomtempo0 == 0)
            {
                Instantiate(EnemyBullet, new Vector3(gameObject.transform.position.x - 2.0f, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z), Quaternion.identity);
                Instantiate(EnemyBullet, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z), Quaternion.identity);
                Instantiate(EnemyBullet, new Vector3(gameObject.transform.position.x + 2.0f, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z), Quaternion.identity);
            }
            if (randomtempo0 == 1)
            {
                Instantiate(EnemyBullet, new Vector3(gameObject.transform.position.x - 1.0f, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z), Quaternion.identity);
                Instantiate(EnemyBullet, new Vector3(gameObject.transform.position.x + 1.0f, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z), Quaternion.identity);
            }

            vrijeme = 0.0f;
            int randomtempo = Random.RandomRange(3, 5);
            randomvrijeme = randomtempo;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name.Contains("Bullet"))
        {
            if (Zivot == 0)
            {
                Destroy(this.gameObject);

                Instantiate(VelikaEksplozija, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.5f, this.gameObject.transform.position.z), Quaternion.identity);

                GameObject gtemp = GameObject.Find("Spawner");

                gtemp.GetComponent<SpawnerControl>().setBrojUbijenih(+1);
            }
            else
            {
                Instantiate(MalaEksplozija, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.5f, this.gameObject.transform.position.z), Quaternion.identity);

                Zivot -= 1;
            }

            Destroy(collision.gameObject);
        }

    }
}
