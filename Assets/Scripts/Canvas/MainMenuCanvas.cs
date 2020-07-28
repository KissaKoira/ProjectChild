﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour {

    public void NewGame() {
        // Number 1 should be the first scene in game after the main menu
        SceneManager.LoadScene(1);
    }

    public void Continue() {
        
    }
}