using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testscript01 : MonoBehaviour
{
    public Text prvi;
    public Text drugi;

    public void POZOVISCENUGAME()
    {
        //PlayerPrefs.SetString("LEVELCONTROL", "3-1-0");
        //PlayerPrefs.SetString("LEVELCONTROLFORMATION", "4-3-5");

        Debug.Log(prvi.text.ToString());
        PlayerPrefs.SetString("LEVELCONTROL", prvi.text.ToString());
        PlayerPrefs.SetString("LEVELCONTROLFORMATION", drugi.text.ToString());

        Application.LoadLevel("Game");
    }
}
