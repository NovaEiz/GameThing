using System;
using GameThing;
using GameThing.UI;
using UnityEngine;
using Zenject;

namespace GameThing {

public class InterfaceGameThingInstaller : MonoInstaller {

#region Private fields

	[Header("GameThingInstaller - Settable fields")]
	[SerializeField] private JumpClickDefinitionView _jumpClickDefinitionView;

#endregion

#region Public methods

	public override void InstallBindings() {
		Container.Inject(_jumpClickDefinitionView);
	}

#endregion

}

}