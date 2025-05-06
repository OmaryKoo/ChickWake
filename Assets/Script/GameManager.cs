using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public GameObject gameclearText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Autumn Scene");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time: " + (int) surviveTime;
        }
        else{
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Autumn Scene");
            }
        }
    }
    public void EndGame()
    {
        isGameOver = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime < bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time: " + (int) bestTime;
    }

    public void GameClear()
    {
        isGameOver = true;
        SceneManager.LoadScene("ClearScene");

        /*float bestTime = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime < bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime",bestTime);
        }
        recordText.text = "Best Time: " + (int) bestTime;*/
    }


}
