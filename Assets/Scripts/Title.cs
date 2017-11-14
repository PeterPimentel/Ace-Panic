using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour {

    public void GoTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
	
}
