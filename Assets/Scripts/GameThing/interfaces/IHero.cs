using System;
using ModestTree.Util;

namespace GameThing {
public interface IHero {
	void Destroy();
	event Action OnDestroyed;
}
}