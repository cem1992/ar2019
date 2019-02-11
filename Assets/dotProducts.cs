using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotProducts : MonoBehaviour
{
    private GameObject airstrip;
    private GameObject spaceshuttle;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
    	airstrip = GameObject.Find("Airstrip");
		spaceshuttle = GameObject.Find("Spaceshuttle");
		
		material = new Material(Shader.Find("Unlit/Color"));
        material.color = Color.red;

        // assign the material to the renderer
        GetComponent<Renderer>().material = material;
    }

    // Update is called once per frame
    void Update(){
    	
    	if (airstrip)
        {
            Vector3 forward = spaceshuttle.transform.TransformDirection(Vector3.forward);
            Vector3 toOther = airstrip.transform.position - transform.position;

            if (Vector3.Dot(forward, toOther) < 0)
            {
                print("The other transform is behind me!");
                
            }
            
        }
    }

    void changeColor(){
    	material = new Material(Shader.Find("Unlit/Color"));
        material.color = Color.green;

        // assign the material to the renderer
        GetComponent<Renderer>().material = material;
    }
}
