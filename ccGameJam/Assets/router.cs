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
    

	// Use this for initialization
	void Start () {

        instantiateSpheres();


    }
	
	// Update is called once per frame
	void Update () {
		
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

            GameObject temp = Instantiate<GameObject>(WiFiWaveSphere, new Vector3(transform.position.x + x, y, transform.position.z + z), new Quaternion(0,0,0,0), this.gameObject.transform);
            temp.transform.LookAt(transform.position);
            Debug.DrawLine(temp.transform.position, temp.GetComponent<wiFiWave>().transform.position, Color.red, 10f);
            //line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / sphereCount);
        }



        

        for (int i = 0; i < sphereCount; i++)
        {

        }
    }
}
