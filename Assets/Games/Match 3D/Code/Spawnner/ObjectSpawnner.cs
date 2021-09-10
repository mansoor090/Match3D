using System;
using System.Collections;
using System.Collections.Generic;
using Match3D;
using UnityEngine;


namespace Match3D
{


	public class ObjectSpawnner : MonoBehaviour
	{

		// <- Public Or Serialized (Private) Variables ->

		[SerializeField] Transform    parentObject;
		[SerializeField] ObjectData[] ObjectsToSpawn;
		[SerializeField] int          numberOfObjects;


		void Start()
		{
			numberOfObjects = 0;
		}

		/// <summary>
		/// Spawn Objects, Pass Surface Reference in "Plane" to have randomPosition in correct dimensions
		/// </summary>
		/// <param name="plane"></param>
		public void SpawnObjects(Transform plane)
		{
			foreach (ObjectData objectData in ObjectsToSpawn)
			{
				objectData.SpawnPrefabs(parentObject, plane.transform.position, new Vector2(plane.localScale.x, plane.localScale.y));
				numberOfObjects += objectData.quantity;
			}
			#if UNITY_EDITOR
			Debug.Log(new Vector2(plane.localScale.x, plane.localScale.y));
			#endif
		}

		/// <summary>
		/// Reduce Only 1 Count
		/// </summary>
		public void ReduceCount()
		{
			numberOfObjects--;
			if (numberOfObjects == 0)
			{
				Debug.Log("Level Fail");
			}
		}

		/// <summary>
		/// Reduce "X" amount of Count
		/// </summary>
		/// <param name="amount"></param>
		public void ReduceCount(int amount)
		{
			numberOfObjects -= amount;
			if (numberOfObjects == 0)
			{
				Debug.Log("Level Fail");
			}
		}

	}


}