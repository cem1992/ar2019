using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public GameObject earth;
    public GameObject meteor;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 earthPosistion = earth.transform.position;
      Vector3 meteorPosistion = meteor.transform.position;
      float distance = Vector3.Distance(earthPosistion, meteorPosistion);
      
      float earthLS_x = earth.transform.lossyScale.x;
      float meteorLS_x = meteor.transform.lossyScale.x;

      float radius_x = (earthLS_x + meteorLS_x) / 2;

      if( distance < radius_x) {
        Explode();
      }

    }
    void Explode () {
       print ("Impact");
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        //Destroy(gameObject, exp.duration);
    }
}
