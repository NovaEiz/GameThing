using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nighday {

public static class GameObjectExt {

	public static bool CompareLayerMask(this GameObject gameObject, LayerMask layerMask) {
		if (layerMask == (layerMask | (1 << gameObject.layer))) {
			return true;
		}

		return false;
	}

}

}