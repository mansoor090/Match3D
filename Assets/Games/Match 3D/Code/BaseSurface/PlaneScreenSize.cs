using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3D
{


	public class PlaneScreenSize : MonoBehaviour
	{

		[SerializeField] InputSystem    input;
		[SerializeField] ObjectSpawnner objectSpawnner;


		void Start()
		{
			// dynamic screen size adjustment for surface
			var height = Camera.main.orthographicSize * 2.0;
			var width  = height * Screen.width        / Screen.height;
			transform.localScale = new Vector3((float) width, (float) height, 0.1f);

			// dynamic screen size clamping for objects
			Vector2 inputSystemScreenClamp = input.ScreenClamp;
			inputSystemScreenClamp.x = transform.localScale.x / 2f;
			inputSystemScreenClamp.y = transform.localScale.y / 2f;
			input.ScreenClamp        = inputSystemScreenClamp;

			// dynamic screen size Collider for blockage
			// so we need 4 colliders to cover up :) 
			Vector3 scale    = new Vector3(transform.localScale.x, 0.2f, transform.localScale.y);
			Vector3 rotation = new Vector3(0,                      0,    90);
			for (int i = 0; i < 2; i++)
			{
				GameObject boundary = GameObject.CreatePrimitive(PrimitiveType.Cube);
				boundary.transform.localScale                 = scale;
				boundary.transform.eulerAngles                = rotation;
				boundary.GetComponent<MeshRenderer>().enabled = false;
				if (i == 0)
				{
					boundary.transform.position = new Vector3(inputSystemScreenClamp.x + 0.2f, 0, 0);
				}
				else
				{
					boundary.transform.position = new Vector3(-inputSystemScreenClamp.x - 0.2f, 0, 0);
				}
			}

			rotation = new Vector3(90, 0, 0);
			for (int i = 0; i < 2; i++)
			{
				GameObject boundary = GameObject.CreatePrimitive(PrimitiveType.Cube);
				boundary.GetComponent<MeshRenderer>().enabled = false;
				boundary.transform.localScale                 = scale;
				boundary.transform.eulerAngles                = rotation;
				if (i == 0)
				{
					boundary.transform.position = new Vector3(0, 0, inputSystemScreenClamp.y + 0.2f);
				}
				else
				{
					boundary.transform.position = new Vector3(0, 0, -inputSystemScreenClamp.y - 0.2f);
				}
			}

			objectSpawnner.SpawnObjects(transform);
		}

	}


}