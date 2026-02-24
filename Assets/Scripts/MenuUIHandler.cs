using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text bestScoreText;

    public void Start()
    {
        int topScore = DataPersistence.Instance.topScore;
        string topName = DataPersistence.Instance.topName;
        bestScoreText.text = $"Best Score : {topName} : {topScore}";
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
        DataPersistence.Instance.playerName = nameInput.text;
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
