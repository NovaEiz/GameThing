
using System;

namespace GameThing {

public interface IEater {
	event Action<IFood> OnEaten;
}

}