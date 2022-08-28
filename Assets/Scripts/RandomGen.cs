using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RandomGen : MonoBehaviour
{

    [Header("SpawnPoints List")]
    public List<GameObject> SpawnPoints = new List<GameObject>();

    [Header("Obstacle Settings")]
    public List<GameObject> ObsList = new List<GameObject>();
      public float obsSpeed = 5;

    [Header("SpawnPoints Timer")]
    public float SP1timer = 100;
    public float SP2timer = 100;
    public float SP3timer = 100;


    [Header("Levelup Settings")]
    public float levelupTimer = 30;
    public int levelNum = 1;
    public Animation textAnim;
    public TextMeshProUGUI textLevelUp;
    public int maxCooldown = 10;
    public int minCooldown = 7;
    


    
    private void Awake() {

     SP1timer = Random.Range(1,3);
     SP2timer = Random.Range(1,3);
     SP3timer =  Random.Range(1,3);
     

    }

    private void Update() {
        

        SP1timer -= Time.deltaTime;
        SP2timer -= Time.deltaTime;
        SP3timer -= Time.deltaTime;
        levelupTimer -= Time.deltaTime;
    
        if(levelupTimer <= 0)
        {
            levelUp();
        }


        if(SP1timer <= 0)
        {
            spawnObj(SpawnPoints[0].gameObject);
            
            SP1timer =  Random.Range(minCooldown,maxCooldown);

     
        }
        if(SP2timer <= 0)
        {
             spawnObj(SpawnPoints[1].gameObject);
                  SP2timer =  Random.Range(minCooldown,maxCooldown);

        }
        if(SP3timer <= 0)
        {
             spawnObj(SpawnPoints[2].gameObject);
                  SP3timer = Random.Range(minCooldown,maxCooldown);
        }



    }

    private void levelUp()
    {
            obsSpeed += 1;
            levelupTimer = 10;
            levelNum++;
            textLevelUp.text = "Level Up - Wave "+levelNum;
            textAnim.Play();

            if(maxCooldown >5)
            {
            maxCooldown -=1;
            }

            if(minCooldown > 2)
            {
            minCooldown -=1;
            }


    }



    private void spawnObj (GameObject spawnPoint)
    {

        int random = Random.Range(0, ObsList.Capacity );

        Instantiate(ObsList[random], new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z), Quaternion.identity);
    }



}
