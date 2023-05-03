using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllers : MonoBehaviour
{
    public void RetryButton() {
        GameManager.Instance.ResetLevel();
    }

    public void StartGameButton() {
        GameManager.Instance.TextScroll();
    }

    public void TextScrollButton() {
        GameManager.Instance.NewGame();
    }
}
