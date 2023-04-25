using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public AudioSource footstepSounds;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
            footstepSounds.enabled = true;
        } else {
            footstepSounds.enabled = false;
        }
    }
}
