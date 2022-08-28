using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    CanvasGroup CG;

    [SerializeField]
    KeyCode PauseKey;


    void Start()
    {
        CG = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(PauseKey))
        {
            if(CG.alpha == 0) // pause is false
            {
                CG.alpha = 1;
                CG.interactable = true;
                Time.timeScale = 0;
            }
            else // pause is true
            {
                CG.alpha = 0;
                CG.interactable = false;
                Time.timeScale = 1;
            }
        }


    }


    public void onClickReturn()
    {
        CG.alpha = 0;
        CG.interactable = false;
        Time.timeScale = 1;
    }

    public void onClickMainMenu()
    {
        Time.timeScale = 1;
        Destroy(GameObject.Find("Music"));
        SceneManager.LoadScene(0);
    }

}
