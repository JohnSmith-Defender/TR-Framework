using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemCam : MonoBehaviour {

	public Transform itemPosition;
	public float displayTime;
	private GameObject curItem;

	// Use this for initialization
	void Start () {
		curItem = null;
	}
	void Update()
	{
		if(curItem!=null)
		curItem.transform.Rotate(0f, 90f*Time.deltaTime, 0f);
	}
	public void SetAndEnable(GameObject item)
	{
		Destroy(curItem);
		curItem = (GameObject)Instantiate(item, itemPosition);
		curItem.gameObject.layer = 5;
		curItem.gameObject.transform.GetChild(0).gameObject.layer = 5;
		curItem.transform.localPosition = Vector3.zero;
		Destroy(curItem, displayTime);
	}
}
