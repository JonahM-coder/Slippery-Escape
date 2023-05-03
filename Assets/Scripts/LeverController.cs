using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    
    //Affected Level Object Variables
    public GameObject target;
    public bool isTriggered;
    public float newPos = 5f;

    //Time Variables
    public bool startTimer = false;
    public float timer = 5f;
    public float timeLeft = 0f; //does not need to be public

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
        startTimer = false;
        timeLeft = timer;
    }

    void Update()
    {
        if(startTimer)
        {
            timeLeft -= 1 * Time.deltaTime;

            if (timeLeft <= 0)
            {
                isTriggered = false;
                target.transform.Translate(0, -newPos, 0f);
                startTimer = false;
            }
            
        }

        if(!startTimer)
        {
            timeLeft = timer;
        }

    }

    // Update is called once per frame
    public void OpenLever()
    {

        if (!isTriggered)
        {
            isTriggered = true;
            startTimer = true;
            target.transform.Translate(0, newPos, 0f);

        }

    }


}
