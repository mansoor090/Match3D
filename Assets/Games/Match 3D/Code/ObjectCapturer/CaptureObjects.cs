using System;
using System.Collections;
using System.Collections.Generic;
using MansoorGlobal;
using Pixelplacement;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Match3D
{


	public class CaptureObjects : MonoBehaviour
	{

		// <- Public Or Serialized (Private) Variables ->
		[SerializeField] ParticleSystem poofParticle;
		[SerializeField] ObjectSpawnner ObjectSpawnner;
		[SerializeField] GameObject     FirstObject;
		[SerializeField] GameObject     SecondObject;
		[SerializeField] Transform[]    Lids;
		[SerializeField] TagNames       acceptableTag;
		

		// <- Private Variables ->
		WaitForSeconds WaitForSeconds = new WaitForSeconds(0.5f);
		
		
		// <- Functions ->

		/// <summary>
		/// This 
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		IEnumerator RemoveObjects()
		{
			yield return WaitForSeconds;


			
			Tween.Position(Lids[0].transform, Lids[0].transform.position - Vector3.right, 0.5f, 0f);
			Tween.Position(Lids[1].transform, Lids[1].transform.position + Vector3.right, 0.5f, 0f);
			
			yield return WaitForSeconds;
			
			Tween.Position(FirstObject.transform,  FirstObject.transform.position  + (Vector3.down * 1.5f), 0.5f, 0f);
			Tween.Position(SecondObject.transform, SecondObject.transform.position + (Vector3.down * 1.5f), 0.5f, 0f);
			
			Tween.Position(Lids[0].transform, Lids[0].transform.position + Vector3.right, 0.5f, 0.1f);
			Tween.Position(Lids[1].transform, Lids[1].transform.position - Vector3.right, 0.5f, 0.1f);
			
			poofParticle.gameObject.SetActive(false);
			poofParticle.gameObject.SetActive(true);
			
			FirstObject = SecondObject = null;
			
			ObjectSpawnner.ReduceCount(2);
			
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag(acceptableTag.ToString()))
			{
				if (FirstObject == null)
				{
					other.gameObject.layer = LayerMask.NameToLayer("Default");
					FirstObject            = other.gameObject;
					Tween.Position(FirstObject.transform, Lids[0].position, 0.5f, 0f);
					Tween.Rotation(FirstObject.transform, Quaternion.identity, 0.5f, 0f);
					Destroy(FirstObject.GetComponent<Rigidbody>());
					return;
				}

				if (FirstObject && other.gameObject.name == FirstObject.name)
				{
					other.gameObject.layer = LayerMask.NameToLayer("Default");
					SecondObject           = other.gameObject;
					Tween.Position(SecondObject.transform, Lids[1].position, 0.5f, 0f);
					Tween.Rotation(SecondObject.transform, Quaternion.identity, 0.5f, 0f);
					Destroy(SecondObject.GetComponent<Rigidbody>());
					StartCoroutine("RemoveObjects");
				}
			}
		}

		void OnTriggerStay(Collider other)
		{
			// no need to check tag here, if rigidbody is destroyed, it wont work. Simple -> :)
			Rigidbody component = other.gameObject.GetComponent<Rigidbody>();
			component.AddForce(Vector3.forward * Random.Range(0.1f, SaveData.Instance.denialForce), ForceMode.VelocityChange);
			component.AddTorque(Vector3.one    * Random.Range(-3f,  3f), ForceMode.VelocityChange);
			return;
		}

	}


}