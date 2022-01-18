using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCommands : MonoBehaviour
    
{
    static int sceneNumber;
   

    public void UpdateScene(int sceneName)
    {
        sceneNumber = sceneName;
        Debug.Log("yfyr6");
    }

    public void Retry()
    {
        if (sceneNumber == 1)
        {
            SceneManager.LoadScene("Boss Battle");
        }
        else if (sceneNumber == 2) 
        {
            SceneManager.LoadScene("ThirdLevel");

        }
        }
    public void MainMenu()
    {
        SceneManager.LoadScene("ThirdLevel");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
