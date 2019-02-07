using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
  private GameObject falcon;
  private GameObject fighter;

  public float rayLength = 100000;
  private Ray ray;
  private RaycastHit hit;
  private Material material;
  //private Vector3 rayOrigin;


  // Start is called before the first frame update
  void Start () {
		falcon = GameObject.Find("MilleniumFalconTarget");
		fighter = GameObject.Find("FighterTarget");
    print(fighter);
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 rayDirection = falcon.transform.rotation * Vector3.forward;
    ray = new Ray(falcon.transform.position, rayDirection);
    if (Input.GetButton("Fire1")){
      Fire();
    }
  }

  // Shot the Laser
  private void Fire(){
      print("You pressed fire");
      Debug.DrawRay(ray.origin, ray.direction * rayLength);
      print(ray.direction);
      // Checks if the RayCast hit something
      if ( Physics.Raycast( ray.origin, ray.direction, out hit, rayLength)){
        print("Fighter hit");
        var exp = fighter.GetComponent<ParticleSystem>();
        exp.Play();
      } else {
        print("And you missed :(");
      }
  }
  void OnRenderObject()
  {

    GL.PushMatrix();
    GL.MultMatrix(transform.localToWorldMatrix);

    if (material == null)
      material = new Material(Shader.Find("Hidden/Internal-Colored"));

    material.SetPass(0);

    GL.Begin(GL.LINES);
    GL.Color(Color.red);
    GL.Vertex(ray.origin);
    GL.Vertex(ray.origin + ray.direction * rayLength);
    GL.End();
    GL.PopMatrix();
  }

}
