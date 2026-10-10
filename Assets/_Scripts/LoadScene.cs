/*
 * Reference
 * [1] Brackeys Channel on Youtube.com
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        Debug.Log("OPTIONS BUTTON CURRENTLY UNDER CONSTRUCTION.");
    }
    public void QuitGame()
    {
        CarMovement.ResetScore();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void QuitApp()
    {
        Debug.Log("Quitting Application ...");
        Application.Quit();
    }
    public void EndGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

}
