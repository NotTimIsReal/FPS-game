using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUi : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI prompText;
    [SerializeField]
    private TextMeshProUGUI deathText;
    [SerializeField]
    private Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.gameObject.SetActive(false);
        restartButton.onClick.AddListener(() =>
        {
            GetComponent<InputManager>().gameObject.SetActive(true);
            SceneManager.LoadScene("Maps");
        });
    }

    public void UpdateText(string promptMessage)
    {
        prompText.text = promptMessage;
    }
    public void DeathText()
    {
        //set position to center
        deathText.text = "You Died";
        restartButton.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;

    }
}
