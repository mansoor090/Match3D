using UnityEngine;


namespace MansoorGlobal
{


	[System.Serializable]
	public class SaveData
	{
	
		// public static SaveData Instance;
		
		static SaveData instance;

		public static SaveData Instance
		{
			get
			{
				if (instance == null)
					instance = new SaveData();
		
				return instance;
			}
		}

	
		public string hashOfSaveData;
		public int    Level;
		public float  throwForce = 10f;
		public float  height  = 4f;
		public float  followSpeed = 3f;
		public float  denialForce = 2f;
	
	
		//Constructor to save actual GameData
		public SaveData()
		{
		}
	
		//Constructor to check any tampering with the SaveData
		public SaveData(int levels, float throwForce, float height, float followSpeed, float denialForce)
		{
			
			this.Level       = levels;
			this.throwForce  = throwForce;
			this.height      = height;
			this.followSpeed = followSpeed;
			this.denialForce = denialForce;
		
		
		}
	
	}


}