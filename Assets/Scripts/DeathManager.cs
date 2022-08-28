using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathManager : MonoBehaviour
{
    CanvasGroup CG;

    public TextMeshProUGUI textScore;
    

    void Start()
    {
        CG = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void playerDeath(int score)
    {
        CG.alpha = 1;
        CG.interactable = true;
        textScore.text = textScore.text + "" + score;
    }


    public void onClickRetry()
    {

        SceneManager.LoadScene(1);
    }

    public void onClickMainMenu()
    {
        Destroy(GameObject.Find("Music"));
        SceneManager.LoadScene(0);
    }

}
