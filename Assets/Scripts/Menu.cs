using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_Text bestScoreText;
    [SerializeField]
    private TMP_InputField inputField;

    private void Start() {
        bestScoreText.text = $"Best score: {GameController.Instance.Data.name}  {GameController.Instance.Data.score}";
    }

    
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnInputChanged(string input)
    {
        GameController.Instance.SetName(input);
    }
}
