using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeSceneOnTimer : MonoBehaviour
{
    public float changeTime;

    public AudioSource toiletSound;

    public float toiletTime;
   
    private void Update()
    {
        changeTime -= Time.deltaTime;
        toiletTime -= Time.deltaTime;

        if (changeTime <= 0) 
        {
            GameManager.Instance.NewGame();
        } else if (toiletTime <= 0 && toiletTime > -1) {
            toiletSound.Play();
        } 
        
    }
}
