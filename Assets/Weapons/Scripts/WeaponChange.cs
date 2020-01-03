using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
        text.GetComponent<Text>().text = "Broń: AK-47 (kaliber 7.62x39mm)";
    }

    public GameObject ak;
    public GameObject pistol;
    public GameObject barrett;
    public GameObject coltM4;
    public Transform text;
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ak.SetActive(false);
            pistol.SetActive(true);
            coltM4.SetActive(false);
            barrett.SetActive(false);
            text.GetComponent<Text>().text = "Broń: Pistolet (kaliber 9mm)";

        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            ak.SetActive(true);
            pistol.SetActive(false);
            coltM4.SetActive(false);
            barrett.SetActive(false);
            text.GetComponent<Text>().text = "Broń: AK-47 (kaliber 7.62x39mm)";

        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            ak.SetActive(false);
            pistol.SetActive(false);
            coltM4.SetActive(true);
            barrett.SetActive(false);
            text.GetComponent<Text>().text = "Broń: M4 (kaliber 5.56x45mm)";
        }

        /*
        if (Input.GetKey(KeyCode.Alpha4))
        {
            ak.SetActive(false);
            pistol.SetActive(false);
            coltM4.SetActive(false);
            barrett.SetActive(true);
        }
        */
    }
}
