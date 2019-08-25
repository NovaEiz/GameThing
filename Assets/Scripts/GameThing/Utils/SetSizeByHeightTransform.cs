using System;
using UnityEngine;

namespace GameThing {

[ExecuteInEditMode]
public class SetSizeByHeightTransform : MonoBehaviour {

#region Private fields

	[Header(" - Settable fields")]
	[SerializeField] private Transform _transform;

#endregion

#region Private methods

	private void Recalculate() {
		var localScale = transform.localScale;
		localScale.x = localScale.y = _transform.localScale.y;
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