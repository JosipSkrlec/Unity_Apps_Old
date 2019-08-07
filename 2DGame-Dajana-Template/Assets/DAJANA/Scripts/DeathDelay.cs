using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDelay : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 6.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
