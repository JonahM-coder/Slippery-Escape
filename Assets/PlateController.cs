using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateController : MonoBehaviour
{
    //Pressure Plate Variables
    public Vector3 originalPos;
    bool moveBack = false;
    public float pushSpeed = -0.1f;
    public float pushLimit_Y = -3f;

    //Affected Level Object Variables
    public GameObject target;
    public bool isTriggered;
    public float newPos = 5f;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveBack)
        {
            if(transform.position.y < originalPos.y)
            {
                transform.Translate(0, 0.01f, 0);
                isTriggered = false;
            }
            else
            {
                moveBack = false;
                isTriggered = true;
            }
        }

    }

    //Occurs only when player is staying in the triggering hitbox
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        //Plate moves down if it recognizes Player game object
        if(collision.transform.name == "Player")
        {
            isTriggered = true;
            transform.Translate(0, pushSpeed, 0);
            moveBack = false;

            if(transform.position.y <= pushLimit_Y)
            {
                moveBack = true;
                isTriggered = false;
                collision.transform.parent = null;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Plate moves down if it recognizes Player game object
        if (collision.transform.name == "Player")
        {
            isTriggered = true;
            collision.transform.parent = transform;
        }

        if (isTriggered)
        {
            target.transform.Translate(0, newPos, 0f);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Plate moves down if it recognizes Player game object
        if (collision.transform.name == "Player")
        {
            moveBack = true;
            isTriggered = false;
            //collision.transform.parent = null;
        }

        if (!isTriggered)
        {
            target.transform.Translate(0, -newPos, 0f);
        }

    }


}
