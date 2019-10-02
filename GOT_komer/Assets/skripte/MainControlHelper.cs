using Assets.skripte;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainControlHelper : MonoBehaviour {

    public GameObject ContentParent;
    public GameObject buttonPrefab;

    int brojac = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }


    public void addnewbutton()
    {
        brojac++;

        foreach (string ListaItem in SeatsSelector.ListaSOP)
        {
            GameObject newButton = Instantiate(buttonPrefab) as GameObject;
            newButton.GetComponentInChildren<Text>().text = ListaItem;
            newButton.name = ListaItem;
                       

            newButton.transform.SetParent(ContentParent.transform, false);
        }

    }


    public void OpenSeat()
    {
        string imebuttona = this.gameObject.name;

        Debug.Log("pritisnut je button " + imebuttona);

        // TODO ACTIVE OBJECT FACK

        var AssignLordToSeatPanel = GameObject.Find("Canvas/AssignLordToSeat");

        AssignLordToSeatPanel.SetActive(true);

        // staviti lordove u dropdown
        AssignLordToSeatPanel.GetComponent<Dropdown>().options.Clear();

        foreach (LORD lord in MainControl.ListaLordova)
        {
            Debug.Log(lord.LordName1);
            AssignLordToSeatPanel.GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() {text = lord.LordName1});
        }

        //this swith from 1 to 0 is only to refresh the visual DdMenu
        AssignLordToSeatPanel.GetComponent<Dropdown>().value = 1;
        AssignLordToSeatPanel.GetComponent<Dropdown>().value = 0;


        if (PlayerPrefs.HasKey(imebuttona) == false)
        {

            
        }
        else
        {
            // staviti iz playerpref u sve fildove

        }



    }





}
