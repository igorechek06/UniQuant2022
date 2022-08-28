using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stert : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void PlayPressed()
    {
        SceneManager.LoadScene("NewGame");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
    public void InsPressed()
    {
        SceneManager.LoadScene("Instruction");
        Debug.Log("kjh");
    }
}

