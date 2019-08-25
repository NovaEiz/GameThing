using System;
using Nighday;
using UnityEngine;
using Zenject;

namespace GameThing {

public class LavaSystem : MonoBehaviour {
	
#region Private fields

	[Header(" - Settable fields")]
	[SerializeField] private GameObjectCollisionHandler _collisionHandler;

#endregion
	
#region Unity Events

	private void OnCollisionEntered(GameObject gameObject) {
		var hero = gameObject.GetComponent<IHero>();
		if (hero != null) {
			hero.Destroy();
		}
	}

#endregion

#region Unity Events

	private void Awake() {
		_collisionHandler.OnCollisionEntered += OnCollisionEntered;
	}

#endregion

}

}