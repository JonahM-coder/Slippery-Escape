using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite[] sprites;
    public float framerate = 1f / 6f;
    private SpriteRenderer spriteRenderer;
    private int frame;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        InvokeRepeating(nameof(Animate), framerate, framerate);
    }

    private void OnDisable() {
        CancelInvoke();
    }

    private void Animate() {
        frame++;

        if (frame >= sprites.Length) {
            frame = 0;
        }

        if (frame >= 0 && frame < sprites.Length) {
            spriteRenderer.sprite = sprites[frame];
        }
    }
}