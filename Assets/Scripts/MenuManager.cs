using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    private GameObject canvas;
    private TextMeshProUGUI bestScoreText;
    private TMP_InputField inputName;
    private string playerName;
    private string saveFilePath;
    private static string bestPlayerName;
    private static int bestScore;

    void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        saveFilePath = Path.Combine(Application.persistentDataPath, "highscore.json");
        LoadHighScore();
        canvas = GameObject.Find("Canvas");
        bestScoreText = canvas.transform.Find("BestScore").GetComponent<TextMeshProUGUI>();
        inputName = canvas.transform.Find("InputFieldName").GetComponent<TMP_InputField>();

        bestScoreText.text = $"Best Score : {bestPlayerName} : {bestScore}";
    }

    public void StartGame()
    {
        playerName = inputName.text;
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    private void LoadHighScore()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            HighScoreData highScoreData = JsonUtility.FromJson<HighScoreData>(json);
            bestPlayerName = highScoreData.playerName;
            bestScore = highScoreData.score;
        }
    }
}
