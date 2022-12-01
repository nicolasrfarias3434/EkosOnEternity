using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartPlay()
    {
        SceneManager.LoadScene("TesseractScene");
    }
}
