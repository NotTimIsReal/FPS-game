using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Maps : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image background;
    [SerializeField]
    private GameObject maps;
    void Start()
    {
        background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        foreach (Transform child in maps.transform)
        {
            child.GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(child.name);
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        background.rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);

    }
}
