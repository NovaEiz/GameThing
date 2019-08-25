using System;
using UnityEngine;
using Zenject;

namespace GameThing {

public class EatingSystem : MonoBehaviour {

#region Private fields

	[Inject]
	private GameController _gameController;

#endregion

#region Private methods

	private void OnEaten(IFood food) {
		food.Destroy();
	}

	private void OnCreatedHero(IHero hero) {
		var eater = hero as IEater;
		eater.OnEaten += OnEaten;
	}

#endregion

#region Public methods
	
	[Inject]
	public void Init() {
		_gameController.OnCreatedHero += OnCreatedHero;
	}

#endregion

}

}