 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class LoadLevels : MonoBehaviour
 {
     public void LoadNewScene()
     {
         UnityEngine.SceneManagement.SceneManager.LoadScene("Level 1");        
     }
 }
 
 