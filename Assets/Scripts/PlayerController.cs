using UnityEngine;

public class PlayerController : MonoBehaviour {
    public HideablePlayer hideablePlayer;
    public float moveSpeed = 2f;
    public float jumpForce = 3f;
    
    
    private Vector2 direction;
    private SpriteRenderer rend;
    private bool canHide = false;
    public bool hiding {get; private set;}
    
    private Rigidbody2D _rb;
    float scaleX;
    private float moveHorizontal;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        scaleX = transform.localScale.x;
    }

    

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (hideablePlayer.IsHidden) {
                hideablePlayer.Unhide();
            }
            else {
                hideablePlayer.Hide();
            }
        }

        if (hideablePlayer.IsHidden) return;

        moveHorizontal = Input.GetAxis("Horizontal");
        Flip();
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
        } else if (other.gameObject.name.Equals("Escape Vent")) {
            GameManager.Instance.NextLevel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Hiding Vat"))
        {
            canHide = false;
        }
    }

    public void Flip() {
        if (moveHorizontal > 0) {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (moveHorizontal < 0) {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

}