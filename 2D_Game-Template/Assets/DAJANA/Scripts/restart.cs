using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BaciNaScenu()
    {
        SceneManager.LoadScene("gamescena");
        PlayerControl.rezz = 0;
    }

}
