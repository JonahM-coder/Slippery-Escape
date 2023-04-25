using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    
    //Affected Level Object Variables
    public GameObject target;
    public bool isTriggered;
    public float newPos = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
    }

    // Update is called once per frame
    public void OpenLever()
    {
        if(!isTriggered)
        {
            isTriggered = true;
            target.transform.Translate(0, newPos, 0f);
            
        }
    }
}
