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

    void UpdateText() {
        scoreText.text = GetStarCollection().ToString();
    }

    public static int GetStarCollection() {
        return starsInCollection;
    }

    public void AddToStarCollection(int amount) {
        starsInCollection += amount;
        UpdateText();
    }

    public void DecreaseFromStarCollection(int amount) {
        Debug.Log("deduct " + amount);
        starsInCollection -= amount;
        UpdateText();
    }
}
