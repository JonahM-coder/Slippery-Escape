using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv5LeverAndDoor : MonoBehaviour
{
  
    public GameObject LevDoorClosed;
    public GameObject LevDoorOpen;

    public GameObject LeverOff;
    public GameObject LeverOn;

    private float timer = 15.0f; // seconds on timer

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
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
        LevDoorClosed.SetActive(false);

        // Render the object to render
        LevDoorOpen.SetActive(true);

        LeverOff.SetActive(false);
        LeverOn.SetActive(true);

        Invoke("TimedRendering", timer);
    }
    
}

    void TimedRendering(){
        LevDoorClosed.SetActive(true);
        LevDoorOpen.SetActive(false);

        LeverOff.SetActive(true);
        LeverOn.SetActive(false);
    }

}
