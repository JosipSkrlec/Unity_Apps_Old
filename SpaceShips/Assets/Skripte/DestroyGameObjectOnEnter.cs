using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectOnEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name.Contains("ProjectileFrom"))
        {
            Destroy(collision.transform.gameObject);
            Debug.Log(collision.transform.name);
        }



    }


}
