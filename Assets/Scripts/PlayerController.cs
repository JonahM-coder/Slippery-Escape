using UnityEngine;

public class PlayerController : MonoBehaviour {
    public HideablePlayer hideablePlayer;
    public float moveSpeed = 2f;
    public float jumpForce = 3f;

    private Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
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

        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal * moveSpeed, _rb.velocity.y);
        _rb.velocity = movement;

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rb.velocity.y) < 0.001f) {
            _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

}