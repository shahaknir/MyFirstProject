using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Manager
{
    public class GameManager : MonoBehaviour
    {

        public enum GameState
        {
            Playing, Mainmenu, Question
        }
        [SerializeField]
        private QuestionManager QuestionCanvas;
        private PlayerMovement movement;

        private GameState gameState;

        private void Start()
        {
            SceneManager.activeSceneChanged += StartGame;
        }




        private void StartGame(Scene arg0, Scene arg1)
        {
            switch (gameState)
            {
                case GameState.Playing:
                    QuestionCanvas = FindObjectOfType<QuestionManager>();
                    break;
                case GameState.Question:
                    QuestionCanvas = FindObjectOfType<QuestionManager>();
                    break;
                default:
                    return;
            }

        }

        public void OnMissionStart()
        {
            ControlPlayerMovement(false);
        }

        public void OnMissionEnd()
        {
            ControlPlayerMovement(true);
        }


        private void ControlPlayerMovement(bool shouldMove)
        {
            movement.enabled = shouldMove;
            QuestionCanvas.gameObject.SetActive(!shouldMove);

            //Todo AssignQuestion
        }
    }
}
