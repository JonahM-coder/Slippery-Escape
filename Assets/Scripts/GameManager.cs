using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameManager Instance { get; private set; }
    public int stage { get; private set; }

    private void Awake() {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy() {
        if (Instance == this) {
            Instance = null;
        }
    }

    public void NewGame() {
        LoadLevel(1);
    }

    public void LoadLevel(int stage) {
        this.stage = stage;

        SceneManager.LoadScene($"Level {stage}");
    }

    public void NextLevel() {
        LoadLevel(stage + 1);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        LoadLevel(stage);
    }

    public void FailLevel() {
        SceneManager.LoadScene("FailScreen");
    }

    public void TextScroll() {
        SceneManager.LoadScene("Opening Text");
    }

    public void CutScene() {
        SceneManager.LoadScene("Cutscene");
    }

}
