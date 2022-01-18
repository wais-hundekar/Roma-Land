using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueTutorial : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject player;
    
    public GameObject textBox;
    
    public GameObject healthBarHero;
   




    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
        player.GetComponent<Movement>().enabled = false;
        
        player.GetComponent<Weapon>().enabled = false;
      


        textBox.SetActive(true);
        
        healthBarHero.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
          
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            player.GetComponent<Movement>().enabled = true;
            
            player.GetComponent<Weapon>().enabled = true;
            textBox.SetActive(false);
            
          
            healthBarHero.SetActive(true);
            
        }
    }
}
