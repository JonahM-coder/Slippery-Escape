using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv4ButtonAndDoor : MonoBehaviour
{
    public GameObject ButtonDoorClosed;
    public GameObject ButtonDoorOpen;

    public GameObject ButtonOff;
    public GameObject ButtonOn;

    private float Lv5ButtonTimer = 23.0f; // seconds on Lv5ButtonTimer

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
   void OnTriggerEnter2D(Collider2D other)
{
    // Check if the object that collided with the trigger has a "Player" tag
    if (other.CompareTag("Player"))
    {
        // Unrender the object to unrender
        ButtonDoorClosed.SetActive(false);

        // Render the object to render
        ButtonDoorOpen.SetActive(true);

        ButtonOff.SetActive(false);
        ButtonOn.SetActive(true);

        Invoke("TimedRendering", Lv5ButtonTimer);

    }
   
}

    void TimedRendering(){
        ButtonDoorClosed.SetActive(true);
        ButtonDoorOpen.SetActive(false);

        ButtonOff.SetActive(true);
        ButtonOn.SetActive(false);
    }



}


