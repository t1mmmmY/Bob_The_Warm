using UnityEngine;
using System.Collections;

public class WarmNode : MonoBehaviour 
{
	private Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	public void TakeNode()
	{
		rigidbody.isKinematic = true;
	}

	public void ReleaseNode()
	{
		rigidbody.isKinematic = false;
	}

	public void FixedNode()
	{
		rigidbody.isKinematic = !rigidbody.isKinematic;
	}

	public void MoveTo(Vector3 position)
	{
		Vector3 newPos = new Vector3(position.x, position.y, transform.position.z);
		transform.position = newPos;
//		transform.position = position;
	}

}
