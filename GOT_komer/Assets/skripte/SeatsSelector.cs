using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeatsSelector : MonoBehaviour {

    public Button HellHolt;
    public Button StarFall;
    public Button MoatCailin;

    public static List<string> ListaSOP = new List<string>(); 

    public void SelectSeat()
    {
        string temp = this.gameObject.transform.name;

        if (ListaSOP.Contains(temp))
        {

            ListaSOP.Remove(temp);

            this.gameObject.GetComponent<Image>().color = Color.white;


        }
        else
        {
            ListaSOP.Add(temp);
            this.gameObject.GetComponent<Image>().color = Color.red;
        }
    }

}
