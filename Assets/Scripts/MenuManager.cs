using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    GameObject DS;

    private void Start() {
        DS = GameObject.FindGameObjectWithTag("DS");
    }


}
