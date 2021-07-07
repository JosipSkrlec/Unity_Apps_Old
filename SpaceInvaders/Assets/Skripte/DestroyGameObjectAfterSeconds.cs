using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectAfterSeconds : MonoBehaviour
{
    public float DestroyAfter = 0.3f;

    private void Start()
    {
        Destroy(this.gameObject, DestroyAfter);
    }
}
