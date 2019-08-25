using System;
using UnityEngine;

namespace GameThing {

public class Thing : MonoBehaviour, IClimber, IJumper, IHero, IEater {
	
#region Private fields

	[Header("Thing - Settable fields")]
	[SerializeField] private Rigidbody _rb;

#endregion

#region IVelcro

	public void Cling() {
		OnCling?.Invoke(this);
		StopJump();
	}

	public event Action<IClimber> OnCling;
	public event Action<IClimber> OnCanceledCling;

#endregion

#region IJumper

	public void Jump() {
		OnJumped?.Invoke(this);
		OnCanceledCling?.Invoke(this);
		_rb.isKinematic = true;
	}

	public event Action<IJumper> OnJumped;
	public event Action<IJumper> OnStopedJump;

	private void StopJump() {
		OnStopedJump?.Invoke(this);
		_rb.isKinematic = false;
	}
	
#endregion

#region IHero

	void IHero.Destroy() {
		Destroy(gameObject);
	}

#endregion

#region IEater
	
	public event Action<IFood> OnEaten;

#endregion

#region Unity Events

	private void OnDestroy() {
		OnDestroyed?.Invoke();
	}

	private void OnTriggerEnter(Collider other) {
		var food = other.gameObject.GetComponent<IFood>();
		if (food != null) {
			OnEaten?.Invoke(food);
		}
	}

#endregion
	
#region Unity Events
	
	public event Action OnDestroyed;

#endregion

}

}