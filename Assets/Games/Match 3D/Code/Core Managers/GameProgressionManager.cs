using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3D
{


	public class GameProgressionManager : MonoBehaviour
	{
		public static GameProgressionManager Instance;

		public enum GameState
		{
			MainMenu      = 0,
			Gameplay      = 1,
			LevelComplete = 2,
			LevelFail     = 3,
			Pause         = 4
		}

		[SerializeField] GameState currentGameState;

		public delegate void GameStateChange(GameState currentState);

		public GameStateChange OnGameStateChange;

		/// <summary>
		/// Change State of game and give callback to those who subscribed the event
		/// </summary>
		public GameState gameState
		{
			get { return currentGameState; }
			set
			{
				if (currentGameState != value)
				{
					currentGameState = value;
					OnGameStateChange.Invoke(currentGameState);
				}
			}
		}

		private void Awake()
		{
			Instance = this;
		}

		/// <summary>
		/// change game state base on given Index
		/// </summary>
		/// <param name="index">index of scene enum</param>
		public void ChangeGameState(int index)
		{
			currentGameState = (GameState) index;
			OnGameStateChange.Invoke(currentGameState);
		}
	}



}

