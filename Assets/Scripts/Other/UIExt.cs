using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nighday {

public class UIExt {

	public static bool CheckPointerOnOverUI() {
		bool             isOverUI = false;
		PointerEventData pointer  = new PointerEventData(EventSystem.current);
		if (Input.GetMouseButtonDown(0)) {
			pointer.position = Input.mousePosition;

			List<RaycastResult> raycastResults = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointer, raycastResults);

			if (raycastResults.Count > 0) {
				isOverUI = true;
				//foreach (var go in raycastResults) {
				//}
			} else {
				isOverUI = false;
			}
		}

		return isOverUI;
	}

}

}