using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

    [SerializeField] public Button playButton;

	// Use this for initialization
	void Start ()
    {
        Button button = playButton.GetComponent<Button>();
        button.onClick.AddListener(LoadGame);
	}
	
    void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
