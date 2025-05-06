using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    public Text clearText;
    public Text recordText;

public void GotoTointro()
{
    SceneManager.LoadScene("IntroScene");
}

void Start()
    {

        float bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        recordText.text = "Best Score: " + (int)bestTime;
        
    }
    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Autumn Scene");
        }
    }
}
