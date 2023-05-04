using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OnCollisionExit : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(nextSceneName);
    }
}
