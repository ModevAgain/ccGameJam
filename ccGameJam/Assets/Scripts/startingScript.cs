using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingScript : MonoBehaviour {

    [SerializeField]
    Material[] signalMats;
    int nextMat = 0;
    [SerializeField]
    Animator anim;


	// Use this for initialization
	void Start () {

        //anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {


        if (GetComponent<Animation>().isPlaying)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
        else { GetComponent<MeshRenderer>().enabled = false; }



	}

    public void startAnim()
    {

        anim.SetTrigger("start");
        Invoke("changeToLowSignal", 3f);
    }

    void changeToLowSignal()
    {
        GetComponent<Renderer>().material = signalMats[nextMat];
        nextMat += 1;
        if(nextMat <=4)
        Invoke("changeToLowSignal", 0.8f);

  
    }
}
