using System;
using UnityEngine;

namespace GameThing {

public class HeroFactory : MonoBehaviour {

#region Private fields

	[Header("HeroFactory - Settable fields")]
	[SerializeField] private GameObject _heroPrefab;
	[SerializeField] private Transform _parent;
	[SerializeField] private Transform _spawn;

#endregion

#region Public methods

	public IHero Create() {
		var hero = Instantiate(_heroPrefab, _parent);
		hero.transform.position = _spawn.position;

		var localPosition = hero.transform.localPosition;
		localPosition.z = 0;
		hero.transform.localPosition = localPosition;
		
		return hero.GetComponent<IHero>();
	}

#endregion

}

}