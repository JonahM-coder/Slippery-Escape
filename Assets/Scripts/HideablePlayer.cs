using UnityEngine;

public class HideablePlayer : MonoBehaviour {
    public bool IsHidden { get; private set; }

    private SpriteRenderer _spriteRenderer;
    private Collider2D _playerCollider;
    private Rigidbody2D _rb;

    void Start() {
        IsHidden = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerCollider = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        
    }

    public void Hide() {
        IsHidden = true;
        _spriteRenderer.enabled = false;
        //_playerCollider.enabled = false;
        Physics2D.IgnoreLayerCollision(3, 6, true);
        _rb.gravityScale = 0;
        _rb.velocity = Vector2.zero;
        
    }

    public void Unhide() {
        IsHidden = false;
        _spriteRenderer.enabled = true;
        Physics2D.IgnoreLayerCollision(3, 6, false);
        //_playerCollider.enabled = true;
        _rb.gravityScale = 1;
    }
}