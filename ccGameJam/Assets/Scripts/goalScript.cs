using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalScript : MonoBehaviour {

    [SerializeField]
    Text signalText;

    [SerializeField]
    float neededTransparency;

	// Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void registerWave(float trans)
    {
        if(trans > 0.3f) { 
        signalText = GameObject.FindGameObjectWithTag("signalText").GetComponent<Text>();
        signalText.text = 100*(trans) + "0% signal";

        for (int i = 0; i < 20; i++)
        {
            Color newColor = signalText.color;
            newColor.a += 0.05f;
            signalText.color = newColor;
        }

            if (neededTransparency <= trans)
            {
                signalText.text = "You did it!";
                return;
            }


        }
    }

    void deactivateSignalText()
    {

        for (int i = 0; i < 20; i++)
        {
            Color newColor = signalText.color;
            newColor.a -= 0.05f;
            signalText.color = newColor;
        }

    }

}
