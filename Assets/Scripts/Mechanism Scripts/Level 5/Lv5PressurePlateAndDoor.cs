using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv5PressurePlateAndDoor : MonoBehaviour
{
    public GameObject PressurePlateDoorClosed;
    public GameObject PressurePlateDoorOpen;

    public GameObject PressurePlateOff;
    public GameObject PressurePlateOn;

    private float timer = 19.0f; // seconds on timer

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
        PressurePlateDoorClosed.SetActive(false);

        // Render the object to render
        PressurePlateDoorOpen.SetActive(true);

        PressurePlateOff.SetActive(false);
        PressurePlateOn.SetActive(true);

        Invoke("TimedRendering", timer);

    }
    
}

    void TimedRendering(){
        PressurePlateDoorClosed.SetActive(true);
        PressurePlateDoorOpen.SetActive(false);

        PressurePlateOff.SetActive(true);
        PressurePlateOn.SetActive(false);
    }

}
