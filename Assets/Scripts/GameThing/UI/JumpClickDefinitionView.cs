using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace GameThing.UI {

public class JumpClickDefinitionView : MonoBehaviour, IPointerClickHandler {

#region Private fields

	[Inject]
	private JumpCommandHandler _jumpCommandHandler;

#endregion

#region Unity Events

	public void OnPointerClick(PointerEventData eventData) {
		_jumpCommandHandler.RunJump();
	}

#endregion

}

}