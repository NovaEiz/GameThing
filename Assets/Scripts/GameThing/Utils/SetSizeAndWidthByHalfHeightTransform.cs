using System;
using UnityEngine;

namespace GameThing {

[ExecuteInEditMode]
public class SetSizeAndWidthByHalfHeightTransform : MonoBehaviour {

#region Private fields

	[Header(" - Settable fields")]
	[SerializeField] private Transform _transform;
	[SerializeField] private Vector2 _scaleOffset;

#endregion

#region Private methods

	private void Recalculate() {
		var localScale = transform.localScale;
		localScale.y = _transform.localScale.y;
		localScale.x = _transform.localScale.y / 2;

		localScale.x -= _scaleOffset.x;
		localScale.y -= _scaleOffset.y;
		
		transform.localScale = localScale;
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