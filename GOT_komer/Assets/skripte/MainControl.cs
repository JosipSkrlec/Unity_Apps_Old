using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour {

    #region public Varijable
    public GameObject PrviPanel;
    public GameObject DrugiPanel;

    #endregion

    // Use this for initialization
    void Start () {
        PrviPanel.SetActive(true);
        DrugiPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    public void OtvoriDrugiScreen()
    {
        PrviPanel.SetActive(false);
        DrugiPanel.SetActive(true);

    }




}
