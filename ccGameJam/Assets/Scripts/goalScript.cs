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

        signalText = GameObject.FindGameObjectWithTag("signalText").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void registerWave(float trans)
    {

        signalText.text = 10*(1 - trans) + "0% of the original signal reached the toilet";

        for (int i = 0; i < 20; i++)
        {
            Color newColor = signalText.color;
            newColor.a += 0.05f;
            signalText.color = newColor;
        }

        if (neededTransparency <= trans) Debug.Log("Win");

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
