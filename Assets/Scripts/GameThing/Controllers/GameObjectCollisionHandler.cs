using System;
using UnityEngine;

namespace GameThing {

public class GameObjectCollisionHandler : MonoBehaviour {

#region Unity Events

	private void OnCollisionEnter(Collision other) {
		OnCollisionEntered?.Invoke(other.gameObject);
	}
	private void OnTriggerEnter(Collider other) {
		OnCollisionEntered?.Invoke(other.gameObject);
	}

#endregion

#region Events

	public event Action<GameObject> OnCollisionEntered;

#endregion

}

}