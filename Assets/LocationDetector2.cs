using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationDetector2 : MonoBehaviour
{
	private GameObject Shuttle;
	private GameObject Earth;
	private GameObject LD;
    void Start()
    {
		Earth = GameObject.Find("Earth");
		Shuttle = GameObject.Find("Spaceshuttle");
		LD = GameObject.Find("LD");
    }

 
    void Update()
    {
	}

	void OnGUI()
	{
		
		Matrix4x4 mat = Matrix4x4.TRS(Shuttle.transform.position, Shuttle.transform.rotation, Shuttle.transform.lossyScale);
		Matrix4x4 Earthmat = Matrix4x4.TRS(Earth.transform.position, Earth.transform.rotation, Earth.transform.lossyScale);
		Matrix4x4 mat2 = Earthmat.inverse * mat;
		Vector3 LP = mat2.MultiplyPoint(LD.transform.localPosition);
		float q = Mathf.Sqrt(LP.x*LP.x + LP.z*LP.z);

   		GUI.color = Color.red;
   		GUI.Label(new Rect(10, 10, 500, 100), "Local position: " + LP.x + " " + LP.y + " "+ LP.z);
		if(0 < LP.z && LP.y < 0.3 && q < 0.5) 
		{  		GUI.color = Color.red;
   		GUI.Label(new Rect(10, 50, 500, 100), "North");
		}
		if(0 > LP.z && LP.y < 0.3 && q < 0.5) 
		{  		GUI.color = Color.red;
   		GUI.Label(new Rect(10, 50, 500, 100), "South");
		}
	}	

	public static Matrix4x4 T (float x, float y, float z)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(1, 0, 0, x));
		m.SetRow(1, new Vector4(0, 1, 0, y));
		m.SetRow(2, new Vector4(0, 0, 1, z));
		m.SetRow(3, new Vector4(0, 0, 0, 1));

		return m;
	}

    public static Matrix4x4 Rx (float a)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(1, 0, 			 0, 			0));
		m.SetRow(1, new Vector4(0, Mathf.Cos(a), -Mathf.Sin(a), 0));
		m.SetRow(2, new Vector4(0, Mathf.Sin(a), Mathf.Cos(a),	0));
		m.SetRow(3, new Vector4(0, 0, 		 	 0, 			1));

		return m;
	}
	    
    public static Matrix4x4 Ry (float a)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(Mathf.Cos(a), 	0, Mathf.Sin(a), 0));
		m.SetRow(1, new Vector4(0, 			  	1, 0, 			 0));
		m.SetRow(2, new Vector4(-Mathf.Sin(a), 	0, Mathf.Cos(a), 0));
		m.SetRow(3, new Vector4(0, 				0, 0, 			 1));

		return m;
	}

    public static Matrix4x4 Rz (float a)
	{
		Matrix4x4 m = new Matrix4x4();

		m.SetRow(0, new Vector4(Mathf.Cos(a), -Mathf.Sin(a), 0, 0));
		m.SetRow(1, new Vector4(Mathf.Sin(a), Mathf.Cos(a),  0, 0));
		m.SetRow(2, new Vector4(0, 			  0, 			 1, 0));
		m.SetRow(3, new Vector4(0, 			  0, 			 0, 1));

		return m;
	}


    public static Matrix4x4 S(float sx,float sy,float sz)
    {
        Matrix4x4 m = new Matrix4x4();

        m.SetRow(0, new Vector4(sx, 0, 0, 0));
        m.SetRow(1, new Vector4(0, sy, 0, 0));
        m.SetRow(2, new Vector4(0,  0,sz, 0));
        m.SetRow(3, new Vector4(0,  0, 0, 1));

        return m;
    }
}