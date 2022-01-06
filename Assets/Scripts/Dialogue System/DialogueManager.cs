using System;
using System.Collections;
using System.Collections.Generic;
using Core.Manager;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    private GameManager game_manager;
    [SerializeField] public Text title_text;
    public string questionTxt;
    [SerializeField]
    private Dialogue dialogue;

    [SerializeField] private InputField input_from_user;

    [SerializeField]
    private Queue<Dialogue.mission> sentences;
    [SerializeField]
    public GameObject button;


    private string question_answer = string.Empty;

    // Use this for initialization
    void Start()
    {
        game_manager = FindObjectOfType<GameManager>();
        sentences = new Queue<Dialogue.mission>();

        input_from_user.onEndEdit.AddListener(OnFinishInput);
    }

    private void OnFinishInput(string answer)
    {
        answer = answer.ToLower();

        bool isCorrect = answer == question_answer;
        if (isCorrect)
            game_manager.OnMissionEnd();
        else
        {
            
            input_from_user.text = "Wrong Answer!!";
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
        title_text.text = firstMission.titleOfTheQuestion;
        question_answer = firstMission.answer.ToLower();
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
