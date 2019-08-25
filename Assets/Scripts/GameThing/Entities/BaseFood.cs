using System;
using UnityEngine;

namespace GameThing {

public class BaseFood : MonoBehaviour, IFood {
	
#region Private fields

	[Header("BaseFly - Settable fields")]
	[SerializeField] private ParticleSystem _effectByDestroyed;
	
#endregion
	
#region Private methods
	
	public void RunDestroyedEffect() {
		var effect = Instantiate(_effectByDestroyed, transform.parent);
		effect.transform.position = transform.position;
	}
	
#endregion
	
#region Public methods
	
	public void Destroy() {
		Destroy(gameObject);
		RunDestroyedEffect();
	}
	
#endregion
	
#region Events

	public event Action OnDestroyed;
	
#endregion
	
#region Unity Events

	private void OnDestroy() {
		OnDestroyed?.Invoke();
	}
	
#endregion

}

}