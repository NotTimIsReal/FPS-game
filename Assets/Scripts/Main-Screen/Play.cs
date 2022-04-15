using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Play : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button play;
    [SerializeField]
    private Image background;
    // Update is called once per frame
    void Start()
    {
        //make image height and width 100
        background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);

    }
    void Update()
    {
        background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        play.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Maps");
        });
    }
}
