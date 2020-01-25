using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectOnEnter : MonoBehaviour
{
    // postavljena je skripta na 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name.Contains("ProjectileFrom"))
        {
            Destroy(collision.transform.gameObject);
        }

        else if (collision.transform.gameObject.name.Contains("UpgradeBonus"))
        {
            Destroy(collision.transform.gameObject);
        }

        else if (collision.transform.gameObject.name.Contains("ShieldBonus"))
        {
            Destroy(collision.transform.gameObject);
        }
    }


}
