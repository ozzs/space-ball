using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{


    private void OnTriggerEnter(Collider other) {
        Destroy(other.gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
    }

}
