using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    [SerializeField] private float x, y, z;

    public void Save() {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        PlayerPrefs.SetFloat("x", x);
        PlayerPrefs.SetFloat("y", y);
        PlayerPrefs.SetFloat("z", z);
    }

    public void Load() {
        PlayerPrefs.GetFloat("x", x);
        PlayerPrefs.GetFloat("y", y);
        PlayerPrefs.GetFloat("z", z);

        Vector3 loadPosition = new Vector3(x, y, z);
        transform.position = loadPosition;
;    }
}
