using System;
using UnityEngine;
using Zenject;

namespace GameThing {

public class FoodGenerator : MonoBehaviour {

#region Private fields

	[Header(" - Settable fields")]
	[SerializeField] private int _amountFood;

	[Inject]
	private FoodFactory _foodFactory;
	
	private int _amountFoodCurrent;

#endregion

#region Private methods

	private void OnDestroyedFly() {
		_amountFoodCurrent--;
	}

	private void CreateFood() {
		var food = _foodFactory.Create();
		food.OnDestroyed += OnDestroyedFly;
	}

	private void AddFood() {
		_amountFoodCurrent++;

		CreateFood();
	}

#endregion

#region Unity Events

	private void Update() {
		if (_amountFoodCurrent < _amountFood) {
			AddFood();
		}
	}

#endregion

#region Events

	public event Action<IFood> OnCreatedFood;

#endregion

}

}