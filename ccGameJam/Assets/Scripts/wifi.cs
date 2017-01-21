using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wifi : MonoBehaviour {

    GameObject waveObject;

	// Use this for initialization
	void Start () {
        spawnWaves();
	}

    void spawnWaves()
    {
        Instantiate<GameObject>(waveObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
