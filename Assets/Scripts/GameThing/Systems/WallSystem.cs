using System;
using System.Collections.Generic;
using Nighday;
using UnityEngine;

namespace GameThing {

public class WallSystem : MonoBehaviour {

#region Private fields

	[Header("WallSystem - Settable fields")]
	[SerializeField] private LayerMask _layerMaskClimber;

	[Space]
	[SerializeField] private float _moveSpeed = 1f;

	[Space]
	[SerializeField] private GameObjectCollisionHandler _leftBorder;
	[SerializeField] private GameObjectCollisionHandler _rightBorder;

	private List<IClimber> _climbers = new List<IClimber>();
	
#endregion

#region Private methods
	
	private void Move(IClimber climber) {
		var tr = climber.transform;
		var pos = tr.position;
		var direction = Vector3.down;
		var toPos = pos + direction * _moveSpeed;
		var step = _moveSpeed * Time.deltaTime;
		tr.position = Vector3.MoveTowards(pos, toPos, step);
	}

	private void CanceledCling(IClimber climber) {
		RemoveItem(climber);
		climber.OnCanceledCling -= CanceledCling;
	}

	private void AddItem(IClimber climber, GameObjectCollisionHandler wall) {
		if (!_climbers.Contains(climber)) {
			_climbers.Add(climber);
			climber.OnCanceledCling += CanceledCling;
			climber.OnDestroyed += () => { _climbers.Remove(climber); };

			var direction = climber.transform.position - wall.transform.position;
			direction.y = 0;
			direction.z = 0;
			direction = direction.normalized;
			climber.transform.rotation = Quaternion.LookRotation(direction);
		}
	}

	private void RemoveItem(IClimber climber) {
		if (_climbers.Contains(climber)) {
			_climbers.Remove(climber);
		}
	}

	private bool CheckObject(GameObject gameObject) {
		if (gameObject.CompareLayerMask(_layerMaskClimber)) {
			return true;
		}
		return false;
	}
	private void ActionWithObject(GameObject gameObject, GameObjectCollisionHandler wall) {
		var climber = gameObject.GetComponent<IClimber>();
		if (climber != null) {
			climber.Cling();
			AddItem(climber, wall);
		}
	}

#endregion

#region Unity Events

	private void Awake() {
		_leftBorder.OnCollisionEntered += (gameObject) => {
			if (CheckObject(gameObject)) {
				ActionWithObject(gameObject, _leftBorder);
			}
		};
		_rightBorder.OnCollisionEntered += (gameObject) => {
			if (CheckObject(gameObject)) {
				ActionWithObject(gameObject, _rightBorder);
			}
		};
	}

	private void Update() {
		foreach (var climber in _climbers) {
			//Move(climber);
		}
	}

#endregion

}

}