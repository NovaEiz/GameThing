using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameThing {

public class JumpSystem : MonoBehaviour {

#region Private fields
	
	[Header("FlySystem - Settable fields")]
	[SerializeField] private float _moveSpeed = 1f;
	
	[Range(1f, 89f)]
	[SerializeField] private float _angleFly = 45f;
	
	[Space]
	[SerializeField] private Transform _area;

	private List<IJumper> _flyers = new List<IJumper>();

#endregion

#region Private methods

	private void Move(IJumper jumper) {
		var tr    = jumper.transform;
		var pos   = tr.position;
		var direction = tr.forward;
		
		var eulerAngles = new Vector3(-_angleFly, tr.eulerAngles.y, 0);

		direction = Quaternion.Euler(eulerAngles) * Vector3.forward;
		var toPos = pos + direction * _moveSpeed;
		var step  = _moveSpeed * Time.deltaTime;
		var nextPosition = Vector3.MoveTowards(pos, toPos, step);

		var maxY = _area.position.y + _area.lossyScale.y / 2;
		if (nextPosition.y > maxY) {
			nextPosition.y = maxY;
		}
		tr.position = nextPosition;
		
		var localPosition = tr.localPosition;
		localPosition.z = 0;
		tr.localPosition = localPosition;
	}

	private void StopedJump(IJumper jumper) {
		RemoveItem(jumper);
		jumper.OnStopedJump -= StopedJump;
	}

#endregion

#region Public methods

	public void AddItem(IJumper jumper) {
		if (!_flyers.Contains(jumper)) {
			_flyers.Add(jumper);
			jumper.OnStopedJump += StopedJump;
			jumper.OnDestroyed += () => { _flyers.Remove(jumper); };
		}
	}

	public void RemoveItem(IJumper jumper) {
		if (_flyers.Contains(jumper)) {
			_flyers.Remove(jumper);
		}
	}

#endregion

#region Unity Events

	private void Update() {
		foreach (var flyer in _flyers) {
			Move(flyer);
		}
	}

#endregion

}

}