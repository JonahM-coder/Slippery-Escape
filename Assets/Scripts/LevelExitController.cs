using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelExitController : MonoBehaviour
{
    public int nextScene = 0;

    //Affected Level Object Variables
    public bool isTriggered;

    public KeyCode interactKey;
    public UnityEvent interactAction;

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
    }

    // Update is called once per frame
    public void OnTriggerEnter2D()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            SceneManager.LoadScene(nextScene);

        }

    }
}
