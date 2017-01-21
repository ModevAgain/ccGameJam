using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionScript : MonoBehaviour {

    //public float outlineWidth = 0.03f;
    [SerializeField]
    GameObject crosshairObject;
    [SerializeField]
    GameObject pickedUpHolder;

    GameObject pickedUpObject;
    GameObject highlightedObject;

	// Use this for initialization
	void Start () {

    }

    // Update is called once per frame
    void Update () {
        if(pickedUpHolder.transform.childCount != 0)
        {
            
            Ray newRay = new Ray(pickedUpHolder.transform.position, pickedUpHolder.transform.position - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(newRay, out hit, 0.5f))
            {
                ShowOutline(new Color(1, 0, 0, 0.5f), pickedUpHolder.transform.GetChild(0).gameObject);
            }
            else
            {
                HideOutline(pickedUpHolder.transform.GetChild(0).gameObject);
            }

        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            checkForObjectWithButton();
        }
        else checkForObject();
	}

    void checkForObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(crosshairObject.transform.position, crosshairObject.transform.forward, out hit))
        {

            if (hit.collider.tag == "pickable")
            {
                highlightedObject = hit.transform.gameObject;
                ShowOutline(new Color(0, 1, 0, 0.5f), highlightedObject);


            }
            else if (highlightedObject != null)
            {
                HideOutline(highlightedObject);
                highlightedObject = null;
            }
            
        }
        else if (highlightedObject != null)
        {
            HideOutline(highlightedObject);
            highlightedObject = null;
        }


           
    }

    public void HideOutline(GameObject obj)
    {
        Debug.Log("Hide outline");
        if (obj.GetComponent<Renderer>() != null)
        {
            obj.GetComponent<Renderer>().material.shader = Shader.Find("Diffuse");
        }
    }


    void checkForObjectWithButton()
    {
        RaycastHit hit;

        if(Physics.Raycast(crosshairObject.transform.position, crosshairObject.transform.forward,out hit))
        {

            if(hit.collider.tag == "pickable")
            {
                hit.transform.GetComponent<interactableScript>().getPickedUp(pickedUpHolder.transform.position);
                hit.transform.parent = pickedUpHolder.transform;
            }
            
            else if (hit.collider.tag == "router")
            {
                hit.transform.GetComponent<interactableScript>().activateRouter();                
            }
            
        }

    }

    public void ShowOutline(Color outlineColor, GameObject obj)
    {

        MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
        if (meshRenderer == null)
        {
            Debug.LogError("mesh renderer is null");
            return;
        }
        Material[] materials = meshRenderer.materials;
        int materialsNum = materials.Length;
        for (int i = 0; i < materialsNum; i++)
        {
            materials[i].shader = Shader.Find("Outlined/Silhouetted Diffuse");
            materials[i].SetColor("_OutlineColor", outlineColor);
        }
    }
}
