using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kontrola : MonoBehaviour
{
    private bool PRVI = true;
    private bool DRUGI = true;

    #region POCETNI KORAK
    public RawImage BackgroundSlika;
    public RawImage LogoStartUp;
    public RawImage ImeStartUp;

    private float fadeinprvi = 0.6f;
    private float fadeinDrugi = 0.0f;
    private float fadeinTreci= 0.0f;
    private bool prvi = false;
    private bool drugi = false;


    public float vrijemeprvi = 0.0f;
    #endregion

    #region DRUGI KORAK
    public float neke = 0.0f;

    #endregion


    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {
        if (PRVI == true)
        {
            PRVIKORAK();
        }
        else if (PRVI == false && DRUGI == true)
        {

        }
        {

        }


    }

    void PRVIKORAK()
    {
        vrijemeprvi += Time.deltaTime;

        if (vrijemeprvi >= 0.05)
        {
            vrijemeprvi = 0.0f;

            fadeinprvi += 0.05f;

            if (prvi == true)
            {
                fadeinDrugi += 0.05f;
            }
            if (drugi == true)
            {
                fadeinTreci += 0.05f;
            }

            if (prvi == true)
            {
                if (fadeinDrugi >= 1.0f)
                {
                    drugi = true;
                    prvi = false;
                }
                else
                {
                    LogoStartUp.GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, fadeinDrugi);
                }

            }
            else if (drugi == true)
            {
                if (fadeinTreci >= 1.0f)
                {
                    PRVI = false;
                }
                else
                {
                    ImeStartUp.GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, fadeinTreci);
                }

            }
            else
            {
                if (fadeinprvi >= 1.0f)
                {
                    prvi = true;
                }
                else
                {
                    BackgroundSlika.GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, fadeinprvi);
                }
            }
        }
           

    }






}
