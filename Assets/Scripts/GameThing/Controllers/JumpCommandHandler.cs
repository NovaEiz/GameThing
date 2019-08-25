using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace GameThing {

public class JumpCommandHandler : MonoBehaviour {

#region Private fields

	[Inject]
	private JumpSystem _jumpSystem;
	[Inject]
	private GameController _gameController;

	private IJumper _jumper;

#endregion

#region region methods
	
	private void OnCreatedHero(IHero hero) {
		_jumper = (IJumper)hero;
		_jumper.OnJumped += (jumperJumped) => {
			_jumpSystem.AddItem(_jumper); 
		};
	}

#endregion

#region Public methods
	
	[Inject]
	public void Init() {
		_gameController.OnCreatedHero += OnCreatedHero;
	}

	public void RunJump() {
		_jumper.Jump();
	}
	
#endregion
	
}

}