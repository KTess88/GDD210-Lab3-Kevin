using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float MouseSensitivity;
	public Transform CamTransform;
	public CharacterController CC;

	private float camRotation = 0f;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		float mouseInputY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;
		camRotation -= mouseInputY;
		camRotation = Mathf.Clamp(camRotation, -90f, 90f);
		CamTransform.localRotation = Quaternion.Euler(camRotation, 0f, 0f);

		float mouseInputX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
		transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX));

		RaycastHit hit;

		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
			{
				EnemyCube enemy = hit.collider.GetComponent<EnemyCube>();

				if (enemy != null)
				{
					Destroy(hit.collider.gameObject);

					SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

					Cursor.lockState = CursorLockMode.None;

				}
			}
		}

	}
}
