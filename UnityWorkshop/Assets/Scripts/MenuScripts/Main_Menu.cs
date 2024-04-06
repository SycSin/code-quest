using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    //Menu Musik
    public AudioSource menuMusic;
    public AudioSource buttonClick;

    
       public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
        public void QuitGame()
        {
            Debug.Log("QUIT!");
            Application.Quit();
        }
}
//player settings 
