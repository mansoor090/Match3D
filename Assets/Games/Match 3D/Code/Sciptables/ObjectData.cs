using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Match3D
{


	



[System.Serializable]
public enum TagNames
{

	Toys,
	Eatables

}

[CreateAssetMenu(fileName = "NewPrefabData", menuName = "ObjectData/CreateNewPrefabData", order = 1)]
public class ObjectData : ScriptableObject
{

	public                                            GameObject prefab;
	[SerializeField]                                  string     prefabName;
	[Tooltip("Make sure this is even number")] public int        quantity = 2;
	public                                            TagNames   myTag;

	void OnValidate()
	{
		prefabName = prefab.name;

		//checking if number is 0 or having odd number
		if (quantity == 0)
		{
			quantity = 2;
		}

		if (quantity % 2 != 0)
		{
			quantity += 1;
		}
	}


	public void SpawnPrefabs(Transform parent,Vector3 CenterPos, Vector2 PositionRange)
	{

		Vector3 randomPosition = CenterPos + GetRandomPosition(PositionRange);
		
		for (int i = 0; i < quantity; i++)
		{
			randomPosition = CenterPos + GetRandomPosition(PositionRange);
			GameObject obj            = Instantiate(prefab, randomPosition, Quaternion.identity, parent);
			obj.name = prefabName;
			obj.tag  = myTag.ToString();
		}
	}
	
	
	Vector3 GetRandomPosition(Vector2 range)
	{
		return new Vector3(Random.Range(-range.x / 2f, range.x / 2f), 1f, Random.Range(-(range.y - 10) / 2f, (range.y - 2f) / 2f));
	}

}

}
