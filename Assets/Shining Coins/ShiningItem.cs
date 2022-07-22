using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiningItem : MonoBehaviour {

	public float shiningTime = 1f;
	public float width = 0.2f;

	Image sr;
	bool isShining = false;

	// Use this for initialization
	void Start () {

        sr = GetComponent<Image>();
        StartCoroutine(Shine());

    }

	IEnumerator Shine () {
		float currentTime = 0;
		float speed = 1f / shiningTime;

		sr.material.SetFloat ("_Width", width);

		while (currentTime <= shiningTime) {
			currentTime += Time.unscaledDeltaTime;
            //Debug.Log("Scaled DeltaTime: " + Time.unscaledDeltaTime);
			float value = Mathf.Lerp (0, 1, speed * currentTime);
			sr.material.SetFloat ("_TimeController", value);
			yield return null;
		}
		yield return new WaitForSecondsRealtime(1f);
		sr.material.SetFloat ("_Width", 0);
		isShining = false;
        yield return new WaitForSecondsRealtime(3f);
        StartCoroutine(Shine());
    }

/*
	Rect GetUVs(Sprite sprite)	{
		Rect uv = sprite.rect;
		uv.x /= sprite.texture.width;
		uv.width /= sprite.texture.width;
		uv.y /= sprite.texture.height;
		uv.height /= sprite.texture.height;
		return uv;
	}
*/


}
