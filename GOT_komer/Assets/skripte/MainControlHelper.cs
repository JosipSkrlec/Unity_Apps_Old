using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameObject newButton = Instantiate(buttonPrefab) as GameObject;
        newButton.name = "ButtonSelectedSeats" + brojac;




        newButton.transform.SetParent(ContentParent.transform, false);





    }






}
