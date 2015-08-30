using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarController : MonoBehaviour {

    public Text scoreText;

    private static int starsInCollection = 50;

	// Use this for initialization
	void Start () {        
        UpdateText();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    
    void UpdateText() {
        scoreText.text = GetStarCollection().ToString();
    }

    int GetStarCollection() {
        return starsInCollection;
    }

    public void AddToStarCollection(int amount) {
        starsInCollection += amount;
        UpdateText();
    }

    public void DecreaseFromStarCollection(int amount) {
        starsInCollection -= amount;
        UpdateText();
    }
}
