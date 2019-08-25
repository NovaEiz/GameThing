using System;
using UnityEngine;

namespace GameThing {

[ExecuteInEditMode]
public class SetPositionInPivotBySide : MonoBehaviour {

#region Private fields

	[Header(" - Settable fields")]
	[SerializeField] private Transform _transform;
	[SerializeField] private SetPositionType _pivot;
	[SerializeField] private SetPositionType _side;
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

	private Vector3 GetPositionPivot() {
		var position = _transform.position;
		switch (_pivot) {
			case SetPositionType.Left:
				position.x -= _transform.localScale.x / 2;
				break;
			case SetPositionType.Right:
				position.x += _transform.localScale.x / 2;
				break;
			case SetPositionType.Top:
				position.y += _transform.localScale.y / 2;
				break;
			case SetPositionType.Bottom:
				position.y -= _transform.localScale.y / 2;
				break;
		}

		return position;
	}
	private Vector3 GetPositionSide() {
		var position = Vector3.zero;
		
		switch (_pivot) {
			case SetPositionType.Left:
				position.x -= transform.localScale.x / 2;
				
				position.x -= _offset.x;
				break;
			case SetPositionType.Right:
				position.x += transform.localScale.x / 2;
				
				position.x += _offset.x;
				break;
			case SetPositionType.Top:
				position.y += transform.localScale.y / 2;
				
				position.y += _offset.y;
				break;
			case SetPositionType.Bottom:
				position.y -= transform.localScale.y / 2;
				
				position.y -= _offset.y;
				break;
		}

		position.y += _offset.y;
		return position;
	}

	private void Recalculate() {
		var positionPivot = GetPositionPivot();
		var positionSide = GetPositionSide();

		var newPosition = positionPivot + positionSide;
		
		transform.position = newPosition;

		var localPosition = transform.localPosition;
		localPosition.z         = 0;
		transform.localPosition = localPosition;

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