﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeater : MonoBehaviour {

    int waveCount = 0;

    [SerializeField]
    GameObject WiFiWaveSphere;
    [SerializeField]
    int sphereCount;
    [SerializeField]
    Transform forwardDir;

    float respawnTimer = 2;
    [SerializeField]
    float respawnTime;

    
    [SerializeField]
    public bool repeaterActive = false;

    bool repeating = false;

    [SerializeField]
    float addForRepeating;

    float transValue;







    // Use this for initialization
    void Start()
    {

  
    }

    // Update is called once per frame
    void Update()
    {


            if (respawnTimer > respawnTime && repeaterActive)
            {
                instantiateSpheres();
            }
            else
            {
                respawnTimer += 1 * Time.deltaTime;
            }
    }

    public void startRepeating(float trans, GameObject waveObject)
    {
        if(!repeaterActive)
        {
            transValue = trans + addForRepeating;
            repeaterActive = true;
            Debug.Log("startRepeating funzt");
        }
       
    }



    void instantiateSpheres()
    {
        float x;
        float y = transform.position.y;
        float z;
        float angle = 20f;

        Vector3 routerPosition = transform.position;

        for (int i = 0; i < (sphereCount + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle);
            z = Mathf.Cos(Mathf.Deg2Rad * angle);

            GameObject temp = Instantiate<GameObject>(WiFiWaveSphere, new Vector3((transform.position.x + x), transform.position.y, (transform.position.z + z)), new Quaternion(0, 0, 0, 0), this.gameObject.transform);
            temp.transform.LookAt(transform.position);
            Color tempColor = temp.GetComponent<Renderer>().material.color;
            tempColor.a = transValue;
            temp.GetComponent<Renderer>().material.color = tempColor;


            angle += (360f / sphereCount);
        }

        for (int i = 0; i < sphereCount; i++)
        {

        }
        respawnTimer = 0;

    }


}