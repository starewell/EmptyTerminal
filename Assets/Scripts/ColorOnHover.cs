using UnityEngine;
using System.Linq;
/* Tint the object when hovered. */

public class ColorOnHover : MonoBehaviour {

	public Color color;

	public Material glowMat;
	float glowAlpha;
	public Renderer meshRenderer;

	//Color[] originalColours;
	Material originalMat;
	bool active;

	void Start() {
		if (meshRenderer == null) {
			meshRenderer = GetComponent<MeshRenderer> ();
		}
		//originalColours = meshRenderer.materials.Select (x => x.color).ToArray ();
		originalMat = meshRenderer.material;
	}

	/*void Update() {
		if (active) {
			glowAlpha = (Mathf.Sin(Time.time * 20) * 0.5f) + 0.5f;
			meshRenderer.material.SetFloat("Alpha", glowAlpha);
			//Debug.Log(glowAlpha);
		}
	}*/

	public void Activate()
	{
		//foreach (Material mat in meshRenderer.materials) {
		//	mat.color += color;
		//}
		meshRenderer.material = glowMat;
		active = true;
	}

	public void Deactivate()
	{
		//for (int i = 0; i < originalColours.Length; i++) {
		//	meshRenderer.materials [i].color = originalColours [i];
		//}
		meshRenderer.material = originalMat;
		active = false;
	}

}