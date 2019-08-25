using System;
using GameThing;
using UnityEngine;
using Zenject;

namespace GameThing {

public class LocationGameThingInstaller : MonoInstaller {

#region Private fields

	[Header("GameThingInstaller - Settable fields")]
	[SerializeField] private JumpSystem _jumpSystem;
	[SerializeField] private WallSystem _wallSystem;
	[SerializeField] private EatingSystem _eatingSystem;
	[SerializeField] private LavaSystem _lavaSystem;

	[Space]
	[SerializeField] private JumpCommandHandler _jumpCommandHandler;
	[SerializeField] private GameController _gameController;
	[SerializeField] private FoodGenerator _foodGenerator;
	
	[Space]
	[SerializeField] private HeroFactory _heroFactory;
	[SerializeField] private FoodFactory _foodFactory;

#endregion

#region Public methods

	public override void InstallBindings() {
		Container.Bind<JumpSystem>().FromInstance(_jumpSystem);
		Container.Bind<WallSystem>().FromInstance(_wallSystem);
		Container.Bind<EatingSystem>().FromInstance(_eatingSystem);
		Container.Bind<LavaSystem>().FromInstance(_lavaSystem);
		
		Container.Bind<JumpCommandHandler>().FromInstance(_jumpCommandHandler);
		Container.Bind<GameController>().FromInstance(_gameController);
		Container.Bind<FoodGenerator>().FromInstance(_foodGenerator);
		
		Container.Bind<HeroFactory>().FromInstance(_heroFactory);
		Container.Bind<FoodFactory>().FromInstance(_foodFactory);
		
		Container.Inject(_jumpSystem);
		Container.Inject(_wallSystem);
		Container.Inject(_eatingSystem);
		Container.Inject(_lavaSystem);
		Container.Inject(_jumpCommandHandler);
		Container.Inject(_gameController);
		Container.Inject(_foodGenerator);
		Container.Inject(_heroFactory);
		Container.Inject(_foodFactory);
	}

	private void Start() {
		_gameController.Run();
	}

#endregion

}

}