using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DSManager : MonoBehaviour
{

    [SerializeField]
    Animation DSAnimation;


    [SerializeField]
    AnimationClip FadeInAnimation;

    [SerializeField]
    AnimationClip FadeOutAnimation;


    int levelToLoad = -1;
    bool isFading = false;




    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(isFading)
        {
            playFadeOut();
            isFading = false;
        }
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }






    public static DSManager instance;
     void Awake()
     {
        
         if (instance != null && instance != this)
             Destroy(this.gameObject);
         else
         {
             instance = this;
             DontDestroyOnLoad(transform.parent.gameObject);
         }
     }




    public void doneFading()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void loadLevel(int levelID)
    {
        playFadeIn();
        isFading = true;
        levelToLoad = levelID;
    }

    public void playFadeIn()
    {
        DSAnimation.clip = FadeInAnimation;
        DSAnimation.Play();
    }

    public void playFadeOut()
    {
        DSAnimation.clip = FadeOutAnimation;
        DSAnimation.Play();
    }


}
