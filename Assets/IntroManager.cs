 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    
    public void StartMainScene(){
        SceneManager.LoadScene("Main");
    }

    public void ExitGame(){
        Application.Quit();
    }
}
