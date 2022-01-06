using System;
using System.Collections;
using System.Collections.Generic;
using Core.Manager;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private GameManager gamemanager;
    [SerializeField] public Text titleText;
    public string questionTxt;
    [SerializeField]
    private Dialogue dialogue;

    [SerializeField] private InputField inputFromUser;

    [SerializeField]
    private Queue<Dialogue.mission> sentences;
    [SerializeField]
    public GameObject button;


    private string questionAnswer = string.Empty;

    // Use this for initialization
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        sentences = new Queue<Dialogue.mission>();

        inputFromUser.onEndEdit.AddListener(OnFinishInput);
    }

    private void OnFinishInput(string answer)
    {
        answer = answer.ToLower();

        bool isCorrect = answer == questionAnswer;
        if (isCorrect)
            gamemanager.OnMissionEnd();
        else
        {
            
            inputFromUser.text = "Wrong Answer!!";
            button.GetComponentInChildren<Text>().text = "If you wish to try again, Click Here";
            //if(button)
        }
    }

    public void StartDialogue()
    {

        foreach (Dialogue.mission sentence in dialogue.questions)
        {
            sentences.Enqueue(sentence);
        }

        Dialogue.mission firstMission = sentences.Dequeue();
        titleText.text = firstMission.titleOfTheQuestion;
        questionAnswer = firstMission.answer.ToLower();
        DisplayNextSentence(firstMission);
    }

    private void DisplayNextSentence(Dialogue.mission firstMission)
    {
        questionTxt = firstMission.theMissionQ;


    }

    // public void DisplayNextSentence()
    // {
    //     if (sentences.Count == 0)
    //     {
    //         EndDialogue();
    //         return;
    //     }

    //     //string sentence = sentences.Dequeue();
    //     StopAllCoroutines();
    //     StartCoroutine(TypeSentence(sentence));
    // }

    // IEnumerator TypeSentence(string sentence)
    // {
    //     //dialogueText.text = "";
    //     foreach (char letter in sentence.ToCharArray())
    //     {
    //         //  dialogueText.text += letter;
    //         yield return null;
    //     }
    // }

}
