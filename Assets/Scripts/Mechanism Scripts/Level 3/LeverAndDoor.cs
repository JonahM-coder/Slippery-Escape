using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Yo Jack here, if you want to look at the code I did for the sprite rendering, check the equivalent scripts for buttons and pressure plates.
// Itll be a lot less cluttered with useless shit than this one

public class LeverAndDoor : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite ClosedLeverDoor; //temp
    public Sprite OpenLeverDoor;
    public GameObject LeverDoorClosed;
    public GameObject LeverDoorOpen;

    public GameObject LevDoorClosed;
    public GameObject LevDoorOpen;

    public GameObject LeverOff;
    public GameObject LeverOn;

    float timer = 22.0f; // seconds on timer

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        ClosedLeverDoor = GetComponent<Sprite>();
        ClosedLeverDoor = LeverDoorClosed.gameObject.GetComponent<SpriteRenderer>().sprite;
        OpenLeverDoor = LeverDoorOpen.GetComponent<SpriteRenderer>().sprite;
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

    }
    else {
        Invoke("TimedRendering", timer);
    }
}

    void TimedRendering(){
        LevDoorClosed.SetActive(true);
        LevDoorOpen.SetActive(false);

        LeverOff.SetActive(true);
        LeverOn.SetActive(false);
    }


   //  private void OnTriggerEnter2D(Collider2D collision)
   // {
    //    if (collision.CompareTag("Lever"))
       // {
         //   collision.gameObject.name.Equals("Lever Gate") = collision.gameObject.GetComponent<SpriteRenderer>().sprite = OpenLeverDoor;
     //   }
   // } 

 


   // private void OnTriggerExit2D(Collider2D collision)
    //{
      //  if (collision.CompareTag("Lever"))
       // {
        //    OpenLeverDoor = Closed
       // }
    // }


}
