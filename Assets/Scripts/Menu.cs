using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Graj()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gra", LoadSceneMode.Single);
    }
   

    public void Ustawienia()
    {
        SceneManager.LoadScene("Opcje", LoadSceneMode.Additive);
    }

    public void Wroc()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }

    public void Wyjdz()
    {
        Application.Quit();
    }

}
