using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiFiWave : MonoBehaviour {

    [SerializeField]
    public GameObject forwardObj;
    [SerializeField]
    float transparancy;
    Color color;
    Material tempMaterial;
    Material transparentMaterial;
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject child;

    // Use this for initialization
    void Start () {

        transform.position = transform.parent.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        child = transform.GetChild(0).gameObject;
        transform.position = Vector3.Lerp(transform.position, transform.GetChild(0).transform.position, speed);

	}
    


    void OnCollisionEnter (Collision other)
    {
        
        if(other.gameObject.tag == "outsideWall")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "insideWall")
        {

            color = GetComponent<Renderer>().material.color;
            Debug.Log(color);
            color.a -= transparancy;
            GetComponent<Renderer>().material.color = color;
            Debug.Log(color);
        }
    }
}
