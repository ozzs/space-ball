using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Music : MonoBehaviour
{

    public AudioSource AS;
    public Slider volumeSlider;

    void Start()
    {
        AS = GetComponent<AudioSource>();
    }





    public static Music instance;
    void Awake()
    {

        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }




    public void sliderChanged()
    {
        AS.volume = volumeSlider.value;
    }

}
