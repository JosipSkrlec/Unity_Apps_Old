using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureAnimation : MonoBehaviour
{
    // brzina kretanja texture vode
    private float BrzinaPoXOsi = 0.0f;
    private float BrzinaPoYOsi = 0.0f;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        float a = Random.Range(0.01f, 0.03f);
        BrzinaPoXOsi = a;
        BrzinaPoYOsi = a;
    }

    void Update()
    {

        float offsetX = Time.time * BrzinaPoXOsi;
        float offsetY = Time.time * BrzinaPoYOsi;

        rend.material.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}
