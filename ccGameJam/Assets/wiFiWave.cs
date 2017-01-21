using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiFiWave : MonoBehaviour {

    [SerializeField]
    public GameObject forwardObj;
    [SerializeField]
    float wallTransparancy;
    [SerializeField]
    float timeTransparancy;
    Color color;
    Material tempMaterial;
    Material transparentMaterial;
    [SerializeField]
    float speed;    
    float transparancyTimer = 5;
    [SerializeField]
    float transparancyTime;

    GameObject lastWall = null;

    // Use this for initialization
    void Start () {

        transform.position = transform.parent.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, transform.GetChild(0).transform.position, speed);

        if (transparancyTimer > transparancyTime)
        {
            reduceTransparancy();            
        }
        else
        {
            transparancyTimer += 1 * Time.deltaTime;
        }

        if (GetComponent<Renderer>().material.color.a == 0)
        {
            Destroy(gameObject);
        }

    }
    
    void reduceTransparancy()
    {
        color = GetComponent<Renderer>().material.color;
        color.a -= timeTransparancy;
        GetComponent<Renderer>().material.color = color;
        transparancyTimer = 0;
    }

    void OnCollisionEnter (Collision other)
    {
        
        if(other.gameObject.tag == "outsideWall")
        {
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "insideWall")
        {
            if(lastWall != other.gameObject)
            {
                lastWall = other.gameObject;

                color = GetComponent<Renderer>().material.color;
                Debug.Log("hit");
                color.a -= wallTransparancy;
                GetComponent<Renderer>().material.color = color;
            }

            
        }
    }
}
