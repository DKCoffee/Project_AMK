using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    [SerializeField] public Button exitButton;

    void Start()
    {
        Button button = exitButton.GetComponent<Button>();
        button.onClick.AddListener(Exit);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
 