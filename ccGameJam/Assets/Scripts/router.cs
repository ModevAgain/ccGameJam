using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class router : MonoBehaviour {

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
    int waveCounter = 1;
    
        

	// Use this for initialization
	void Start () {

        mainCamera = Camera.main;
        topDownCam = GameObject.Find("TopDownCam").GetComponent<Camera>();
        topDownCam.gameObject.SetActive(false);
        List<List<GameObject>> waveHolderList = new List<List<GameObject>>();
    }
	
	// Update is called once per frame
	void Update () {        

        if (Input.GetKeyDown(KeyCode.E))
        {
            routerActive = false;
            UIHolder.SetActive(false);
            waveCounter = 1;
            for (int i = 0; i < waveCounter; i++)
            {                
                if (GameObject.Find("wave" + i).transform.GetChild(i) == null)
                {
                    Destroy(GameObject.Find("wave" + i));
                }
            }
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
        GameObject wave = new GameObject();

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
            temp.transform.parent = wave.transform;
            wave.transform.parent = gameObject.transform;
            wave.name = "wave" + waveCounter;           
        }
        
        respawnTimer = 0;
        waveCounter++;

        //for (int i = 0; i < sphereCount; i++)
        //{

        //}
    }
}
