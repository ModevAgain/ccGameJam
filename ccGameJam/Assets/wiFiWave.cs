using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiFiWave : MonoBehaviour {

    [SerializeField]
    public GameObject forwardObj;

    // Use this for initialization
	void Start () {
        transform.position = forwardObj.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        
		
	}
    


    void OnCollisionEnter (Collision other)
    {
        Debug.Log("haaaallo");
        if(other.gameObject.tag == "outsideWall")
        {
            Destroy(gameObject);
        }
    }
}
