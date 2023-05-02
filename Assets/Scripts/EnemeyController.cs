using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemeyController : MonoBehaviour {
    public Transform startPoint;
    public Transform endPoint;
    public Transform temp;
    public SpriteRenderer testSR;
    public float speed;
    public bool startMoving = true;
    public bool facingStartingDirection = true;
    public float delay = 0;
    // changed to 5f for testing change if needed
    public float raycastDistance = 5f;

    private bool _movingToEndPoint = true;
    private float _currentDelay = 0;

    private void Awake() {
        testSR = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (startMoving) {
            if (_currentDelay <= 0) {
                // Switched to facingStartingDirection to copy the direction the sprite ends up facing
                Vector2 direction = facingStartingDirection
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
                if (Mathf.Abs(transform.position.y - hit.collider.transform.position.y) < 1.0f) {
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

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("FailScreen");
        }
        
    }
    

    private void Move(Vector2 direction) {
        transform.Translate(direction * speed * Time.deltaTime);
       

        if (Vector2.Distance(transform.position, endPoint.position) < 0.5f) {
            temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;
            // line 82 is what flips the sprites left to right and vice versa
            testSR.flipX = !testSR.flipX;
            // This is to integrate with line 59 so it's false when
            _movingToEndPoint = !_movingToEndPoint;
        }
        // Section is not necessary since sprite moves from A to B and vice versa with the destination being what endPoint.Position ends up being in line 77
        // else if (Vector2.Distance(transform.position, startPoint.position) < 0.5f) {

        //     temp = endPoint;
        //     endPoint = startPoint;
        //     startPoint = temp;
        //     Debug.Log('b');
        //     // testSR.flipX = false;
        // }
    }
}