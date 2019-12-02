﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectOnEnter : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.name.Contains("Projectile"))
        {
            Destroy(collision.transform.gameObject);

        }

    }
}
