﻿using UnityEngine;
using System.Collections;

public class ClickGameboard : MonoBehaviour 
{
    public int boardX;
    public int boardY;
    public int pieceNum;
    private static bool firstMove = true;
    private GameCore gameCore;

    private bool gameOver = false;

	// Use this for initialization
	void Start () 
    {
        gameCore = GameObject.Find("GameCore").GetComponent<GameCore>();
	}
	
	// Update is called once per frame
	void Update () { }

    void OnMouseDown()
    {
        gameCore.currentRow = boardX;
        gameCore.currentCol = boardY;

        if (!gameOver)
        {
            if (firstMove)
            {
                gameCore.PlacePiece(this);
                gameObject.collider.enabled = false;
                firstMove = false;
            }
            else //if (gameCore.isValidMove(boardX, boardY))
            {
                if (gameCore.isValidMove(boardX, boardY))
                {
                    gameCore.PlacePiece(this);
                    gameObject.collider.enabled = false;
                    
                    if (gameCore.isGameOver())
                        gameOver = true;
                }
            }
        }
        
        // if game is over
        // do game over stuff
        // (call a method in GameCore.cs)

        if(gameOver)
        {
            Debug.Log("Game Over!");
        }

        //Debug.Log("gameOver: " + gameOver);
    }
}
