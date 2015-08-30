using UnityEngine;
using System.Collections;

public class Trophy : MonoBehaviour {

    public float growStarEverySecond;

    [Range(0, 100)]
    public int starAmount;

    private Animator anim;
    private StarController starController;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        starController = FindObjectOfType<StarController>();
        //Grow star
        InvokeRepeating("GrowStar", growStarEverySecond, growStarEverySecond);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    //Called as animation event at the end of grow star animation
    public void AddStars() {
        starController.AddToStarCollection(starAmount);
    }

    void GrowStar() {
        anim.SetTrigger("growStar");        
    }
}
