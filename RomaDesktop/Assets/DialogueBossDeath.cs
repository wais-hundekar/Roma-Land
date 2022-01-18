using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogueBossDeath : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject player;
    public GameObject Boss;
    public GameObject textBox;
    public GameObject enemy;
    public GameObject healthBarHero;
    public GameObject healthBarBoss;

    public GameObject bossDeath;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
        player.GetComponent<Movement>().enabled = false;
        Boss.GetComponent<Boss>().enabled = false;
        player.GetComponent<Weapon>().enabled = false;
        enemy.GetComponent<shootingman>().enabled = false;


        textBox.SetActive(true);
        healthBarBoss.SetActive(false);
        healthBarHero.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            Debug.Log("foiajfaoijfoiaej");
        }

        if (Boss == null)
        {
            SceneManager.LoadScene("End CutScene");
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
            Debug.Log("jdaiuwjuidijseiufjaiuejfiawew");
            textDisplay.text = "";
            continueButton.SetActive(false);
            player.GetComponent<Movement>().enabled = true;
       
            player.GetComponent<Weapon>().enabled = true;
            textBox.SetActive(false);
            enemy.GetComponent<shootingman>().enabled = true;
            healthBarBoss.SetActive(true);
            healthBarHero.SetActive(true);
            bossDeath.GetComponent<BossDeath>().enabled = true;

        }
    }
}
