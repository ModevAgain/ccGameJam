using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingManager : MonoBehaviour {

    GameObject playerObject;
    GameObject smartphoneObject;


	// Use this for initialization
	void Start () {

        GameObject.FindGameObjectWithTag("TopDownCam").SetActive(false);
        Camera.main.enabled = true;

        GameObject.FindGameObjectWithTag("smartphone").GetComponent<startingScript>().startAnim();
        GameObject.FindGameObjectWithTag("smartphone").transform.parent.GetChild(1).GetComponent<Renderer>().enabled = true; 

        Invoke("startAnim", 5f);
		

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void startAnim()
    {
        Camera.main.GetComponent<Animation>().Play("headAnim");
    }
}
