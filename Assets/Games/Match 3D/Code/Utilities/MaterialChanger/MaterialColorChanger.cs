using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MansoorGlobal
{


	public class MaterialColorChanger : MonoBehaviour
	{

		[SerializeField] string _ColorID = "Color";
		[SerializeField] Color  bodyColor;


		Renderer              _renderer;
		MaterialPropertyBlock _propBlock;


		void OnValidate()
		{
			SetColor();
		}

		void OnEnable()
		{
			SetColor();
		}


		void SetColor()
		{
			// if condition shortcut if language version is C# v8.0..   2019 is based on C# v7.3
			#if Unity_2020
				_propBlock ??= new MaterialPropertyBlock();
				_renderer ??= GetComponent<Renderer>();
			#endif

			#if UNITY_2019
			
			if (_propBlock == null)
			{
				_propBlock = new MaterialPropertyBlock();
			}
			
			if (_renderer == null)
			{
				_renderer = GetComponent<Renderer>();
			}
			
			#endif

			
		

			// Get the current value of the material properties in the renderer.
			_renderer.GetPropertyBlock(_propBlock);
			// Assign our new value.
			_propBlock.SetColor(_ColorID, bodyColor);
			// Apply the edited values to the renderer.
			_renderer.SetPropertyBlock(_propBlock);
		}

	}


}