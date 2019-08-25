using System;
using UnityEngine;

namespace GameThing {
public interface IClimber {
	Transform transform { get; }
	
	void Cling(); // Прилипнуть
	event Action<IClimber> OnCling; // Прилипнуть
	event Action<IClimber> OnCanceledCling;
	event Action OnDestroyed;
}

}