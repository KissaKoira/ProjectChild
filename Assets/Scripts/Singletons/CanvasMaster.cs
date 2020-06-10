﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMaster : MonoBehaviour {
    // Make class static and destroy if script already exists
    private static CanvasMaster _instance; // **<- reference link to the class
    public static CanvasMaster Instance { get { return _instance; } }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

<<<<<<< HEAD
    public GameObject dialogueCanvas;
=======
    public GameObject dialogueCanvas, statGainCanvas;

    // Store questions and replies so they can be looped through
    public Dictionary<Mood, List<string>> askedQuestions { get; private set; }
    public Dictionary<WordsType, List<string>> givenReplies { get; private set; }
>>>>>>> toni

    void Start() {
        // Enable canvases when game starts to fix fps hiccups when opening them
        dialogueCanvas.SetActive(true);
<<<<<<< HEAD
=======
        statGainCanvas.SetActive(true);

        // Initialize saved questions and replies
        askedQuestions = new Dictionary<Mood, List<string>>();
        givenReplies = new Dictionary<WordsType, List<string>>();
    }

    public void SaveCanvasValues(Save save) {
        save.askedQuestions = askedQuestions;
        save.givenReplies = givenReplies;
    }

    public void LoadCanvasValues(Save save) {
        askedQuestions = save.askedQuestions;
        givenReplies = save.givenReplies;
>>>>>>> toni
    }

    public void OpenDialogue() {
        dialogueCanvas.GetComponent<DialogueScript>().ShowDialogue();
    }
<<<<<<< HEAD
=======

    public void ShowStatGain(string gainedStats) {
        statGainCanvas.GetComponent<StatGainCanvas>().ShowStatGain(gainedStats);
    }
>>>>>>> toni
}