using System;
using System.Collections;
using System.Collections.Generic;
using MansoorGlobal;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Match3D
{


	public class LevelManager : MonoBehaviour
	{

		public static LevelManager Instance;
		public        bool         isPlaying = false;
		
		// Start is called before the first frame update
		void Awake()
		{
			Instance = this;
			LoadGame();
			Vibration.Init();
			isPlaying = false;
		}

		void OnEnable()
		{
			GameProgressionManager.Instance.OnGameStateChange += OnGameStateChange;
		}

		void LoadGame()
		{
			SaveLoad.LoadProgress();
		}


		void OnGameStateChange(GameProgressionManager.GameState gameState)
		{
			switch (gameState)
			{
				case GameProgressionManager.GameState.MainMenu:
					break;

				case GameProgressionManager.GameState.Gameplay:
					isPlaying = true;
					break;

				case GameProgressionManager.GameState.LevelComplete:
					isPlaying = false;

					// Level Save Logic
					Vibration.VibrateSuccess();
					break;

				case GameProgressionManager.GameState.LevelFail:
					isPlaying = false;
					// Level Fail Logic
					Vibration.VibrateFailure();
					break;
			}
		}


		private void OnDestroy()
		{
			GameProgressionManager.Instance.OnGameStateChange -= OnGameStateChange;
		}


		public void ReloadScene()
		{
			SceneManager.LoadScene(0);
		}
	}


}