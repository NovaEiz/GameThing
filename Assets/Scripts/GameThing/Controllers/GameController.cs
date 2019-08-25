using System;
using System.Xml.Schema;
using UnityEngine;
using Zenject;

namespace GameThing {

public class GameController : MonoBehaviour {

#region Private fields

	[Inject]
	private HeroFactory _heroFactory;
	
	private IHero _hero;

#endregion

#region Private methods

	private void CreateHero() {
		_hero = _heroFactory.Create();
		_hero.OnDestroyed += () => {
			_hero = null;
			OnGameOver?.Invoke();
		};
		OnCreatedHero?.Invoke(_hero);
	}

#endregion

#region Public methods

	public void Run() {
		Restart();
	}

	public void Restart() {
		if (_hero != null) {
			_hero.Destroy();
		}

		CreateHero();
	}

#endregion

#region Unity Event methods

	private void Awake() {
		OnGameOver += Restart;
	}

#endregion

#region Events

	public event Action<IHero> OnCreatedHero;
	public event Action OnGameOver;

#endregion

}

}