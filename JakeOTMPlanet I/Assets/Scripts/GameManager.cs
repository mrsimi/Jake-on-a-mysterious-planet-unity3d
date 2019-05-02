using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
	menu,
	inGame,
	gameOver
}

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas gameOverCanvas;

	public int collectedCoins = 0;

	public GameState currentGameState = GameState.menu;

	void Awake(){
		instance = this;
	}

	void Start(){
		currentGameState = GameState.menu;
	}

	void Update(){
		if(Input.GetButtonDown("s")){
			StartGame();
		}
	}

	//called to start the game 
	public void StartGame(){
		PlayerController.instance.StartGame();
		SetGameState(GameState.inGame);
	}

	
	//called when player die
	public void GameOver(){
		SetGameState(GameState.gameOver);
	}

	//called when player decides to go back to the menu
	public void BackToMenu(){
		SetGameState(GameState.menu);
	}

	void SetGameState(GameState newGameState){
		if(newGameState == GameState.menu){
			//setup unity scene for menu state
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			gameOverCanvas.enabled =false;
		}
		else if(newGameState == GameState.inGame){
			//setup unity scene for inGame state
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			gameOverCanvas.enabled = false;
		}
		else if(newGameState == GameState.gameOver){
			//setup unity scene for gameOver state
			menuCanvas.enabled = false;
			inGameCanvas.enabled=false;
			gameOverCanvas.enabled = true;
			//LevelGenerator.instance.pieces = null;
		}

		currentGameState = newGameState;
	}

	public void CollectedCoin(){
		collectedCoins++;
	}
}

