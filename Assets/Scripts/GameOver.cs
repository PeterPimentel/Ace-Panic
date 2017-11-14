using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public Text score;
    public Text record;

	// Use this for initialization
	void Start () {
        score.text = PlayerPrefs.GetInt("score").ToString();
        record.text = PlayerPrefs.GetInt("recorde").ToString();
	}

    public void GoTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
