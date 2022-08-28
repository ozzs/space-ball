using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsMovement : MonoBehaviour
{
 
     GameObject randomGen;




    private void Awake() {
        randomGen =  GameObject.Find("RandomGen").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
          GetComponent<Rigidbody>().velocity = new Vector3(randomGen.GetComponent<RandomGen>().obsSpeed,0,0);
    }
}
