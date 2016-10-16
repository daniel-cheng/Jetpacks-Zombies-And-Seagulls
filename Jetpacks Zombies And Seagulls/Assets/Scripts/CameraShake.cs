using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	private static Vector3 originPosition;

	private static Quaternion originRotation;

	public static float shake_decay;

	public static float shake_intensity;

	private static bool shaking;

	private static Transform _transform;

	void OnEnable() {

		_transform = transform;

	}

	void Update (){

		if(!shaking)
			return;

		if (shake_intensity > 0f) {
			_transform.localPosition = originPosition + Random.insideUnitSphere * shake_intensity;
			_transform.localRotation = new Quaternion (

				originRotation.x + Random.Range (-shake_intensity, shake_intensity) * .2f,

				originRotation.y + Random.Range (-shake_intensity, shake_intensity) * .2f,

				originRotation.z + Random.Range (-shake_intensity, shake_intensity) * .2f,

				originRotation.w + Random.Range (-shake_intensity, shake_intensity) * .2f);

			shake_intensity -= shake_decay;

		} else {
			Debug.Log ("stopped shaking");
			shaking = false;
			_transform.localPosition = originPosition;
			_transform.localRotation = originRotation;
		}
	}

	public static void Shake(){
		if(!shaking) {
			originPosition = _transform.localPosition;
			originRotation = _transform.localRotation;
		}
		shaking = true;
		shake_intensity = .5f;
		shake_decay = 0.002f;
	}
		
}