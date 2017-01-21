using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class router : MonoBehaviour {

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

    Camera mainCamera;
    Camera topDownCam;
    [SerializeField]
    public bool routerActive = false;
    [SerializeField]
    GameObject UIHolder;
        

	// Use this for initialization
	void Start () {
        
        mainCamera = Camera.main;
        topDownCam = GameObject.Find("TopDownCam").GetComponent<Camera>();
        topDownCam.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.E))
        {
            routerActive = false;
            UIHolder.SetActive(false);
            waveCount = 0;
        }

        if (routerActive)
        {
            mainCamera.gameObject.SetActive(false);
            topDownCam.gameObject.SetActive(true);
            UIHolder.SetActive(true);            
        }
        else
        {
            mainCamera.gameObject.SetActive(true);
            topDownCam.gameObject.SetActive(false);
        }

        if (respawnTimer > respawnTime && routerActive)
        {
            instantiateSpheres();
        }
        else
        {
            respawnTimer += 1 * Time.deltaTime;
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

            GameObject temp = Instantiate<GameObject>(WiFiWaveSphere, new Vector3((transform.position.x + x), transform.position.y, (transform.position.z + z)), new Quaternion(0,0,0,0), this.gameObject.transform);
            temp.transform.LookAt(transform.position);

            angle += (360f / sphereCount);
        }



        

        for (int i = 0; i < sphereCount; i++)
        {

        }
        respawnTimer = 0;

    }
}
