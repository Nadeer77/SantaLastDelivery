using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Homescript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
