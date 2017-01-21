using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiFiWave : MonoBehaviour {

    [SerializeField]
    public GameObject forwardObj;
    [SerializeField]
    float wallTransparancy = 0.3f;
    [SerializeField]
    float reduceTransparencyTime = 0.1f;
    Color color;
    Material tempMaterial;
    Material transparentMaterial;
    [SerializeField]
    float speed;    
    float transparencyTimer = 5;
    [SerializeField]
    float transparencyTime = 1.0f;
    [SerializeField]
    float alpha;

    GameObject lastWall = null;

    // Use this for initialization
    void Start () {

        transform.position = transform.parent.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        alpha = GetComponent<Renderer>().material.color.a;
        transform.position = Vector3.Lerp(transform.position, transform.GetChild(0).transform.position, speed);

        if (transparencyTimer > transparencyTime)
        {
            reduceTransparancy();            
        }
        else
        {
            transparencyTimer += 1 * Time.deltaTime;
        }

        if (GetComponent<Renderer>().material.color.a <= 0.05)
        {
            Destroy(gameObject);
        }

        //Debug.DrawRay(transform.position, -transform.forward);

    }
    
    void reduceTransparancy()
    {
        color = GetComponent<Renderer>().material.color;
        color.a -= reduceTransparencyTime;
        GetComponent<Renderer>().material.color = color;
        transparencyTimer = 0;
    }

    void OnCollisionEnter (Collision other)
    {
        if(other.gameObject.tag == "repeater")   
        {
            Debug.Log("tag funzt");
            other.gameObject.GetComponent<repeater>().startRepeating(gameObject.GetComponent<Renderer>().material.color.a,transform.parent.gameObject);
        }

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
                color.a -= wallTransparancy;
                GetComponent<Renderer>().material.color = color;
            }            
        }

        if(other.gameObject.tag == "reflectable")
        {
            Vector3 normalVec = other.contacts[0].normal;
            Vector3 forwardVec = transform.forward;
            float ang = Vector3.Angle(forwardVec, normalVec); 
                      
            Vector3 newDir = 2 * (Vector3.Dot(forwardVec, Vector3.Normalize(normalVec))) * Vector3.Normalize(normalVec) - forwardVec;
            newDir *= -1;

            Quaternion lookDir = Quaternion.LookRotation(newDir);
            transform.rotation = lookDir;

        }

    }
}
