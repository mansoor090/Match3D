using System.Collections;
using System.Collections.Generic;
using MansoorGlobal;
using Match3D;
using UnityEngine;


namespace Match3D
{


	public class GameplaySetting : MonoBehaviour
	{

		[Header("Input System Settings")] [SerializeField] InputSystem  playerInput;
		[SerializeField]                                   SliderBinder ThrowSlider;
		[SerializeField]                                   SliderBinder HeightSlider;
		[SerializeField]                                   SliderBinder FollowSlider;


		[Header("Wrong Selection Setting")] [SerializeField] SliderBinder denialThrow;

		void OnEnable()
		{
			ThrowSlider.Init("Throw Force", SaveData.Instance.throwForce, new Vector2(1, 100f), (float value) =>
			{
				playerInput.ThrowForce       = value;
				SaveData.Instance.throwForce = value;
				SaveLoad.SaveProgress();
			});
			HeightSlider.Init("Lift Height", SaveData.Instance.height, new Vector2(1f, 6f), (float value) =>
			{
				playerInput.Height       = value;
				SaveData.Instance.height = value;
				SaveLoad.SaveProgress();
			});
			FollowSlider.Init("Object Follow Speed", SaveData.Instance.followSpeed, new Vector2(1f, 10f), (float value) =>
			{
				playerInput.LerpSpeed         = value;
				SaveData.Instance.followSpeed = value;
				SaveLoad.SaveProgress();
			});
			denialThrow.Init("Denial Throw Back", SaveData.Instance.denialForce, new Vector2(0.1f, 2f), (float value) =>
			{
				SaveData.Instance.denialForce = value;
				SaveLoad.SaveProgress();
			});
		}

		public void Reset()
		{
			SaveLoad.DeleteProgress();
			SaveLoad.SaveProgress();
		}

	}


}