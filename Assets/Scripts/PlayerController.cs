using UnityEngine;

public class PlayerController : MonoBehaviour {
    public HideablePlayer hideablePlayer;
    public float moveSpeed = 2f;
    public float jumpForce = 3f;
    
    private Collider2D[] results;
    private Vector2 direction;

    private bool climbing;
    private Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void CheckCollision() {
        climbing = false;

         Vector2 size = GetComponent<Collider>().bounds.size;
        size.y += 0.1f;
        size.x /= 2f;

        int amount = Physics2D.OverlapBoxNonAlloc(transform.position, size, 0f, results);

        for (int i = 0; i < amount; i++)
        {
            GameObject hit = results[i].gameObject;

            if (hit.layer == LayerMask.NameToLayer("Pipe"))
            {
                climbing = true;
            }
        }

    }

    void Update() {
       CheckCollision();

        if (climbing)
    {
        direction.y = Input.GetAxis("Vertical") * moveSpeed;
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
}