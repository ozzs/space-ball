using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    Vector3 v3Force;

    [SerializeField]
    Vector3 JumpForce;


    [SerializeField]
    int RotationSpeed;



    [SerializeField]
    KeyCode MovementKeyPos;


    [SerializeField]
    KeyCode MovementKeyNeg;


    [SerializeField]
    KeyCode JumpKey;


    [SerializeField]
    GameObject DeathManager;
    [SerializeField]
    GameObject RandomManager;
    [SerializeField]
    GameObject PauseManager;

    [SerializeField]
    Material BallMat;



    bool onFloor = false;
    bool isDead = false;
    public Color color;
    float _intensity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(JumpKey))
        {
            if (onFloor == true)
            {
                GetComponent<Rigidbody>().velocity += JumpForce;
                onFloor = false;
                
            }
        }


        if(!onFloor)
        {
            if (_intensity < 7)
            {
                BallMat.SetVector("_EmissionColor", color * _intensity);
                _intensity += 1f;
            }
        }
        else
        {
            if (_intensity > 0)
            {
                BallMat.SetVector("_EmissionColor", color * _intensity);
                _intensity -= 0.1f;
            }

        }

    }

    private void FixedUpdate()
    {

        if (isDead == false)
        {
            if (Input.GetKey(MovementKeyPos))
            {
                GetComponent<Rigidbody>().velocity += v3Force;
            }

            if (Input.GetKey(MovementKeyNeg))
            {
                GetComponent<Rigidbody>().velocity -= v3Force;
            }



            transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        
        }
        if (collision.gameObject.tag == "Enemy")
        {
            DeathManager.GetComponent<Canvas>().enabled = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            DeathManager.GetComponent<DeathManager>().playerDeath(RandomManager.GetComponent<RandomGen>().levelNum);
            RandomManager.GetComponent<RandomGen>().textLevelUp.enabled = false;
            RandomManager.GetComponent<RandomGen>().enabled = false;
            PauseManager.SetActive(false);
            isDead = true;
        }
    }



}
