using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarController : MonoBehaviour {

    public Text scoreText;
    public enum Status { SUCCESS, FAILURE };

    private int starsInCollection = 100;    

	// Use this for initialization
	void Start () {        
        UpdateText();
	}

    void UpdateText() {
        scoreText.text = GetStarCollection().ToString();
    }

    public int GetStarCollection() {
        return starsInCollection;
    }

    public void AddToStarCollection(int amount) {
        starsInCollection += amount;
        UpdateText();
    }

    public Status DeductFromStarCollection(int amount) {
        //Can't deduct if not enough stars in collection to spend
        if (starsInCollection >= amount) {
            starsInCollection -= amount;
            UpdateText();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
        
    }
}
