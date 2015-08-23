using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    private Button[] buttonArray;

    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    // Use this for initialization
    void Start() {
        GetComponent<SpriteRenderer>().color = Color.black;
        buttonArray = FindObjectsOfType<Button>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnMouseDown() {                
        //Set all buttons to black before changing the selected button to white
        foreach (Button thisButton in buttonArray) {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;        
        //Selected Defender is static so we can Instantiate the chosen prefab when we want, using Button.selectedDefender
    }
}
