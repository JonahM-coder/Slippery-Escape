using UnityEngine;

public class PlayerController : MonoBehaviour {
    public HideablePlayer hideablePlayer;
    public float moveSpeed = 2f;
    public float jumpForce = 3f;
    
    
    private Vector2 direction;
    private SpriteRenderer rend;
    private bool canHide = false;
    private bool hiding = false;
    
    private Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    

    void Update() {
       // CheckCollision();

       if (canHide && Input.GetKey("up"))
       {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        rend.sortingOrder = 0;
        hiding = true;
        gameObject.GetComponent<Renderer>().enabled = false;
       }
       else
       {
        Physics2D.IgnoreLayerCollision(3, 6, false);
        rend.sortingOrder = 2;
        hiding = false;
        gameObject.GetComponent<Renderer>().enabled = true;
       } 


        if (Input.GetKeyDown(KeyCode.Q)) {
            if (hideablePlayer.IsHidden) {
                hideablePlayer.Unhide();
            }
            else {
                hideablePlayer.Hide();
            }
        }

        if (hideablePlayer.IsHidden) return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal * moveSpeed, _rb.velocity.y);
        _rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rb.velocity.y) < 0.001f) {
            _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Hiding Vat"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Hiding Vat"))
        {
            canHide = false;
        }
    }

}