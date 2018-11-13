using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour {
    public GameObject locationText;
    public GameObject healthDisplay;
    public GameObject hybridatron;
    public bool hybridatronVisible = false;
    public bool locationTextVisible = false;
    public bool healthDisplayVisible = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        this.locationText.SetActive(locationTextVisible);
        this.healthDisplay.SetActive(healthDisplayVisible);
        this.hybridatron.SetActive(hybridatronVisible);
	}
}
