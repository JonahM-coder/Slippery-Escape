using UnityEngine;

public class EnemeyController : MonoBehaviour {
    public Transform startPoint;
    public Transform endPoint;
    public float speed;
    public bool startMoving = true;
    public float delay = 0;
    public float raycastDistance = 1f;

    private bool _movingToEndPoint = true;
    private float _currentDelay = 0;

    void Update() {
        if (startMoving) {
            if (_currentDelay <= 0) {
                Vector2 direction = _movingToEndPoint
                    ? endPoint.position - transform.position
                    : startPoint.position - transform.position;
                direction.Normalize();

                CheckPlayerDetection(direction);

                Move(direction);
            }
            else {
                _currentDelay -= Time.deltaTime;
            }
        }
        else {
            _currentDelay = delay;
        }
    }

    private void CheckPlayerDetection(Vector2 direction) {
        // Cast a ray to detect player collisions
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance,
            LayerMask.GetMask("Player"));
        if (hit.collider != null) {
            // Check if player is hidden
            Debug.Log("Collider detected: " + hit.collider.gameObject.name);
            HideablePlayer hideablePlayer = hit.collider.GetComponent<HideablePlayer>();
            if (hideablePlayer == null || !hideablePlayer.IsHidden) { // ||  
                Debug.Log("player is not hidden");
                // Check if player is on the same platform level
                if (Mathf.Abs(transform.position.y - hit.collider.transform.position.y) < 0.1f) {
               // Check if enemy is facing player
                    if ((_movingToEndPoint && transform.position.x < hit.collider.transform.position.x) ||
                        (!_movingToEndPoint && transform.position.x > hit.collider.transform.position.x)) {
                        // Kill player
                        Debug.Log("kill");
                        Destroy(hit.collider.gameObject);
                    }
                } else {Debug.Log("platform check");}
            }
            else {
                Debug.Log("player is hidden");
            }
        }
    }

    private void Move(Vector2 direction) {
        transform.Translate(direction * speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, endPoint.position) < 0.3f) {
            _movingToEndPoint = false;
        }
        else if (Vector2.Distance(transform.position, startPoint.position) < 0.3f) {
            _movingToEndPoint = true;
        }
    }
}