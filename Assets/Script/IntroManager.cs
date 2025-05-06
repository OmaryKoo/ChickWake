using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{

    public void startGame()
    {
        SceneManager.LoadScene("Autumn Scene");
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        SceneManager.LoadScene("Autumn Scene");
    }
}
