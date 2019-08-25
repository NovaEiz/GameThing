using System;
using UnityEngine;

namespace GameThing {

[ExecuteInEditMode]
public class SetPositionInLeftPivotByRight : MonoBehaviour {

#region Private fields

	[Header(" - Settable fields")]
	[SerializeField] private Transform _transform;
	[SerializeField] private SetPositionType _setPositionType;
	[SerializeField] private Vector2 _offset;

#endregion

#region Private methods

	private void RecalculatePositionLeft() {
		var positionInTarget = _transform.position;
		positionInTarget.x -= _transform.localScale.x / 2;
		var position = positionInTarget;
		position.x         -= transform.localScale.x / 2;
		position.x -= _offset.x;
		position.y -= _offset.y;
		transform.position =  position;
		
		var localPosition = transform.localPosition;
		localPosition.z         = 0;
		transform.localPosition = localPosition;
	}

	private void RecalculatePositionRight() {
		var positionInTarget = _transform.position;
		positionInTarget.x += _transform.localScale.x / 2;
		var position = positionInTarget;
		position.x         += transform.localScale.x / 2;
		position.x += _offset.x;
		position.y += _offset.y;
		transform.position =  position;
		
		var localPosition = transform.localPosition;
		localPosition.z = 0;
		transform.localPosition = localPosition;

	}

	private void Recalculate() {
		switch (_setPositionType) {
			case SetPositionType.Left:
				RecalculatePositionLeft();
				break;
			case SetPositionType.Right:
				RecalculatePositionRight();
				break;
		}
	}

#endregion

#region Unity Event methods

	private void Start() {
		Recalculate();
	}
	private void Update() {
		Recalculate();
	}

#if UNITY_EDITOR
	private void OnValidate() {
		Recalculate();
	}
#endif

#endregion

}

}