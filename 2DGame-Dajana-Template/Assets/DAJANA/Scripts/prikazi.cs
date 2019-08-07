using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prikazi : MonoBehaviour {

    public Text rezultat;

	// Use this for initialization
	void Start () {

        rezultat.text = PlayerControl.rezz.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
