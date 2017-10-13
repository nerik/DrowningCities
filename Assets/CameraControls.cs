using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraControls : MonoBehaviour
{
	[SerializeField]
	public Button zoomInBtn;

	[SerializeField]
	public Button zoomOutBtn;

	[SerializeField]
	public Image fade;


	void OnEnable()	{
		Debug.Log (fade);

		//Register Button Events
		zoomInBtn.onClick.AddListener(() => zoomIn());
		zoomOutBtn.onClick.AddListener(() => zoomOut());
	}

	public void StartIntro() {
		Debug.Log ("StartIntro");
		this.transform.localPosition = new Vector3 (0, 16, -300);
		DOTween.defaultEaseType = Ease.Linear;
		Sequence seq = DOTween.Sequence();
		seq.Append(transform.DOMoveZ(0, 4).SetDelay(.5f).SetEase(Ease.Linear));
		seq.Join(fade.DOColor(Color.black, 2).SetDelay(2).OnComplete(Step2));
			//.OnComplete(Test)
	}

	void Step2() {
		Debug.Log ("step2");
	}

	private void zoomIn() {
		Debug.Log ("zoom in: ");
	}
	private void zoomOut() {
		Debug.Log ("zoom out: ");
	}


}