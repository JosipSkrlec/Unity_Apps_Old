using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectAfterSeconds : MonoBehaviour
{
    public float DestroyAfter = 1.0f;

    private void Start()
    {
        Destroy(this.gameObject, DestroyAfter);
    }
}
