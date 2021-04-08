using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Sprite easy;
    public Sprite medium;
    public Sprite hard;

    public void EasyGame()
    {
        Settings.Background = easy;
        Settings.Missing = Random.Range(9, 13);
        SceneManager.LoadScene("Loading Screen");
    }
    
    public void MediumGame()
    {
        Settings.Background = medium;
        Settings.Missing = Random.Range(18, 22);
        SceneManager.LoadScene("Loading Screen");
    }
    
    public void HardGame()
    {
        Settings.Background = hard;
        Settings.Missing = Random.Range(40, 50);
        SceneManager.LoadScene("Loading Screen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
