using UnityEngine;
using System.Collections;

public class DestroyOldMap : MonoBehaviour {
	
	public static bool NeedToDestroy = false;

	void Update () {
	if (NeedToDestroy) {
			
			int i;
			GameObject[] ToDestroy = GameObject.FindGameObjectsWithTag("ToDestroy");
			Debug.Log("Destroying " + ToDestroy.Length.ToString() + " objects");
			for (i=0;i<ToDestroy.Length;i++)
				GameObject.Destroy(ToDestroy[i]);
			NeedToDestroy = false;
		}
	}
}
