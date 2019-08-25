using System;
using ModestTree.Util;
using UnityEngine;

namespace GameThing {
public interface IJumper {
	Transform transform { get; }

	void Jump();
	event Action<IJumper> OnJumped;
	event Action<IJumper> OnStopedJump;
	event Action OnDestroyed;
}
}