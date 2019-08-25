using System;

namespace GameThing {

public interface IFood {
	void Destroy();
	event Action OnDestroyed;
}

}