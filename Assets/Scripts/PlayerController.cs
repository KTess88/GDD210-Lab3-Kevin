using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float MouseSensitivity;
	public Transform CamTransform;

	

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		float xmouseinput = Input.GetAxis("Mouse X");
		float ymouseinput = Input.GetAxis("Mouse Y");

		transform.Rotate(new Vector3(0, xmouseinput * MouseSensitivity, 0));
		CamTransform.Rotate(new Vector3(-ymouseinput * MouseSensitivity, 0, 0));

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


				}
			}
		}

	}
}
