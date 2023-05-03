using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepSounds;
    public HideablePlayer hideablePlayer;
    // public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        if (hideablePlayer.IsHidden) {
            footstepSounds.enabled = false;
            return;
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow)) {
            footstepSounds.enabled = true;
        } else {
            footstepSounds.enabled = false;
        }
        
    }
}
