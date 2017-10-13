using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Map;
using Mapbox.Unity.Map;
using Mapbox.Utils;

public class Main : MonoBehaviour {

	//AbstractMap map;

	public Transform Map;
	Transform map;

	[SerializeField] Transform mapContainer;
	CameraControls cameraControls;

	int currentCityIndex = -1;


	List<Vector2d> CITIES = new List<Vector2d> { 
		new Vector2d(41.3825, 2.17694),
		new Vector2d(40.71031250340588, -74.00493621826172),
		new Vector2d(42.3605, -71.0596)
	};

	// Use this for initialization
	void Start () {
		#if !UNITY_EDITOR && UNITY_WEBGL
		UnityEngine.WebGLInput.captureAllKeyboardInput = false;
		#endif
		Application.ExternalCall("onUnityAppReady", "Hello from Unity!");
		Debug.Log (Camera.main);
		cameraControls = Camera.main.transform.GetComponent<CameraControls> ();
		this.CreateMap();

	}

	void CreateMap (string rawLatLng = null) {
		if (map != null) {
			Destroy (map.gameObject);
		}

		Vector2d latLng;
		if (rawLatLng == null) {
			currentCityIndex = (currentCityIndex == CITIES.Count - 1) ? 0 : currentCityIndex + 1;
			latLng = CITIES [currentCityIndex];
		} else {
			string[] rawLatLngArr = rawLatLng.Split (new char[] {','});
			Debug.Log (rawLatLngArr [0]);
			Debug.Log(rawLatLngArr[1]);
			latLng = new Vector2d (
				float.Parse (rawLatLngArr [0]),
				float.Parse (rawLatLngArr [1])
			);
		}

		cameraControls.StartIntro ();

		map = Instantiate(Map, new Vector3(0, 0, 0), Quaternion.identity);

		map.GetComponent<AbstractMap>().CenterLatitudeLongitude = latLng;
		map.parent = mapContainer;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			Debug.Log("space key was pressed");

		}
		/*
		if (Input.GetMouseButtonDown (0)) {
			this.CreateMap("40.71031250340588,-74.00493621826172");
		}
		*/
	}

	public void SetLatLng (string message) {
		this.GetComponent<GUIText>().text = message;
		this.CreateMap (message);

	}
}
