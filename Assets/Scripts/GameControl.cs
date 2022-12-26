using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        GoToMenu();
        GamePause();
    }

    void GoToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MenuPrincipal");
    }

    void GamePause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = (Time.timeScale + 1) % 2;
        }
    }
}
