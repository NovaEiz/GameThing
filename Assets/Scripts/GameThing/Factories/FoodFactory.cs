using System;
using UnityEngine;

namespace GameThing {

public class FoodFactory : MonoBehaviour {

#region Private fields

	[Header("FliesFactory - Settable fields")]
	[SerializeField] private GameObject _foodPrefab;
	[SerializeField] private Transform _parent;
	[SerializeField] private Transform _transformArea;

#endregion

#region Public methods

	public Vector3 GetVector2InTransformArea(Transform areaTr) {
		var scale = areaTr.lossyScale;
		var sizeXHalf = scale.x/2;
		var sizeYHalf = scale.y/2;
		var posInArea = new Vector3(
			UnityEngine.Random.Range(-sizeXHalf, sizeXHalf),
			UnityEngine.Random.Range(-sizeYHalf, sizeYHalf),
			0
		);
		
		var pos = posInArea + areaTr.position;

		return pos;
	}

	public IFood Create() {
		var food = Instantiate(_foodPrefab, _parent);
		food.transform.position = GetVector2InTransformArea(_transformArea);

		var localPosition = food.transform.localPosition;
		localPosition.z = 0;
		food.transform.localPosition = localPosition;
		
		return food.GetComponent<IFood>();
	}

#endregion

}

}