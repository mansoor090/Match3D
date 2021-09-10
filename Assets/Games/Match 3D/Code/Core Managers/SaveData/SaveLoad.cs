using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;


namespace MansoorGlobal
{


	public class SaveLoad
	{

		public static void SaveProgress()
		{
			SaveData.Instance.hashOfSaveData = HashGenerator(SaveObjectJSON());
			string saveDataHashed = JsonUtility.ToJson(SaveData.Instance, true);
			File.WriteAllText(GetSavePath(), saveDataHashed);
		}

		static SaveData SaveObjectCreator()
		{
			SaveData checkSave = new SaveData(SaveData.Instance.Level, SaveData.Instance.throwForce, SaveData.Instance.height, SaveData.Instance.followSpeed, SaveData.Instance.denialForce);
			return checkSave;
		}

		static string SaveObjectJSON()
		{
			string saveDataString = JsonUtility.ToJson(SaveObjectCreator(), true);
			return saveDataString;
		}

		public static void LoadProgress()
		{
			if (File.Exists(GetSavePath()))
			{
				string fileContent = File.ReadAllText(GetSavePath());
				JsonUtility.FromJsonOverwrite(fileContent, SaveData.Instance);
				#if !UNITY_EDITOR
			//File tampering checks
			if ((HashGenerator (SaveObjectJSON()) != SaveData.Instance.hashOfSaveData)) {
				// SaveData.Instance = null;
				// SaveData.Instance = new SaveData();
				DeleteProgress ();
				SaveProgress ();
				Debug.LogWarning ("Save file modification detected, Resetting your progress !");
			}
				#endif
				Debug.Log("Game Load Successful --> " + GetSavePath());
			}
			else
			{
				Debug.Log("New Game Creation Successful --> " + GetSavePath());
				SaveProgress();
			}
		}

		static string HashGenerator(string saveContent)
		{
			SHA256Managed crypt  = new SHA256Managed();
			string        hash   = string.Empty;
			byte[]        crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(saveContent), 0, Encoding.UTF8.GetByteCount(saveContent));
			foreach (byte bit in crypto)
			{
				hash += bit.ToString("x2");
			}

			return hash;
		}

		public static void DeleteProgress()
		{
			if (File.Exists(GetSavePath()))
			{
				File.Delete(GetSavePath());
			}
		}

		static string GetSavePath()
		{
			return Path.Combine(Application.persistentDataPath, "SavedGame.json");
		}
		#if UNITY_EDITOR

		[MenuItem("Mansoor/Saved Data/SaveGame All Progress")]
		static void SaveGameProgress()
		{
			SaveProgress();
			EditorUtility.DisplayDialog("Save Progress", "Saved Progress is Renewed", "Ok");
		}

		[MenuItem("Mansoor/Saved Data/Reset All Progress %#r")]
		static void ResetProgress()
		{
			DeleteProgress();
			EditorUtility.DisplayDialog("Reset Progress", "Saved Progress is Reset", "Ok");
		}

		[MenuItem("Mansoor/Saved Data/Open Save File %#o")]
		static void OpenSave()
		{
			Process.Start(Application.persistentDataPath);
		}
		#endif

	}


}