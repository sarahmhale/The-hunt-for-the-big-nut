using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform xForm_Camera;
	private Transform xForm_Parent;

	protected Vector3 localRotation;
	protected float cameraDistance = 10f;

	public float mouseSensitivity = 4f;
	public float scrollSensitivity =2f;
	public float orbitSpeed = 10f;
	public float scrollSpeed = 6f; 

	public bool cameraDisabled = false;

	void Start () {
		this.xForm_Camera = this.transform;
		this.xForm_Parent = this.transform.parent; 
	}

	void rotate(){
		if (Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0) {
			localRotation.x += Input.GetAxis ("Mouse X") * mouseSensitivity;
			localRotation.y += Input.GetAxis ("Mouse Y") * mouseSensitivity;
			localRotation.y= Mathf.Clamp(localRotation.y, 0f,90f);
		}
	}

	void zoom(){
		if (Input.GetAxis ("Mouse ScrollWheel")!= 0f) {
			float scrollAmount = Input.GetAxis ("Mouse ScrollWheel") *scrollSpeed;

			//scroll fast when far way from target and slower when close
			scrollAmount *= (this.cameraDistance * 0.3f);

			this.cameraDistance += scrollAmount * -1f;
			this.cameraDistance = Mathf.Clamp (this.cameraDistance, 1.5f, 100f);
		}
	}

	void cameraTransform(){
		Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
		this.xForm_Parent.rotation = Quaternion.Lerp (
			this.xForm_Parent.rotation, 
			QT, 
			Time.deltaTime * orbitSpeed);

		if (this.xForm_Camera.localRotation.z != this.cameraDistance * -1f) {

			this.xForm_Camera.localPosition = new Vector3 (0f, 0f, Mathf.Lerp (
				this.xForm_Camera.localPosition.z,
				this.cameraDistance * -1f, 
				Time.deltaTime * scrollSpeed)
			);
		}
	}

	void LateUpdate () {
		
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			cameraDisabled = !cameraDisabled;
		}

		if (!cameraDisabled) {
			rotate ();
			zoom ();
		}

		cameraTransform ();

	}
}
