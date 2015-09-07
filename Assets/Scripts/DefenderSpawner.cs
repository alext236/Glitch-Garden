using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent;
    private StarController starController;

    // Use this for initialization
    void Start() {
        starController = FindObjectOfType<StarController>();
        CreateParentFolder();
    }

    private void CreateParentFolder() {
        defenderParent = GameObject.Find("Defender");
        if (defenderParent == null) {
            defenderParent = new GameObject("Defender");
        }
    }
    //This class uses a box collider
    public void OnMouseDown() {
        SpawnSelectedDefender();
    }

    private void SpawnSelectedDefender() {
        GameObject selectedDefender = Button.selectedDefender;        

        //Deduct spawned defender's star value from collection if there's enough 
        int starsNeeded = selectedDefender.GetComponent<Defender>().GetStarValue();
        if (starController.DeductFromStarCollection(starsNeeded) == StarController.Status.FAILURE) {
            return;
        }
        //Spawn the selected defender after deducting required cost
        Vector3 spawnPos = GetSpawnPosOnMouseClick();
        GameObject newDefender = Instantiate(selectedDefender, spawnPos, Quaternion.identity) as GameObject;
        newDefender.transform.SetParent(defenderParent.transform);                     

    }

    private Vector3 GetSpawnPosOnMouseClick() {
        //Spawn position is the position of the mouse click, rounded to nearest int, in world space unit
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);        

        spawnPos.x = Mathf.RoundToInt(spawnPos.x);
        spawnPos.y = Mathf.RoundToInt(spawnPos.y);
        spawnPos.z = 0f;

        return spawnPos;
    }
}
