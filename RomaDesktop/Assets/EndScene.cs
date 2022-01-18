using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{

    public GameObject return1;
    public GameObject return2;
    public GameObject text1;
        public GameObject text2;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        return1.SetActive(true);
        text1.SetActive(true);
    }
    public void Continue()
    {
        return1.SetActive(false);
        text1.SetActive(false);

        return2.SetActive(true);
        text2.SetActive(true);
        count += 1;
            if(count == 2)
        {
            SceneManager.LoadScene("ThirdLevel");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
