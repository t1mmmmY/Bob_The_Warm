using UnityEngine;
using System.Collections;

public class WarmPicker : MonoBehaviour 
{
	Camera mainCamera;
	WarmNode pickUpNode;

	void Start()
	{
		mainCamera = Camera.main;
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			TryToPickUp();
		}

		if (Input.GetMouseButtonUp(0))
		{
			TryToReleaseNode();
		}

		if (Input.GetMouseButtonUp(1))
		{
			TryToFixedNode();
		}

		if (pickUpNode != null)
		{
			MoveWarmNode();
		}
	}

	void TryToPickUp()
	{
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

//		LayerMask mask = new LayerMask();
//		mask.value = LayerMask.NameToLayer("Warm");

		if (Physics.Raycast(ray, out hit, 100, 1 << 8))
		{
			pickUpNode = hit.collider.GetComponent<WarmNode>();
			if (pickUpNode != null)
			{
				pickUpNode.TakeNode();
			}
		}
	}

	void TryToReleaseNode()
	{
		if (pickUpNode != null)
		{
			pickUpNode.ReleaseNode();
			pickUpNode = null;
		}
	}

	void TryToFixedNode()
	{
		if (pickUpNode != null)
		{
//			pickUpNode.FixedNode();
			pickUpNode = null;
		}
	}

	void MoveWarmNode()
	{
		Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

//		LayerMask mask = new LayerMask();
//		mask.value = LayerMask.NameToLayer("Default");

		if (Physics.Raycast(ray, out hit, 100, ~(1 << 8)))
		{
			pickUpNode.MoveTo(hit.point);
		}
	}

}
