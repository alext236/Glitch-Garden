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

    public void OnMouseDown() {
        SpawnSelectedDefender();
    }

    private void SpawnSelectedDefender() {
        //Can't spawn if there is not enough stars left
        if (IsThereEnoughStarsToSpawn() == false) {
            return;
        }
        Vector3 spawnPos = GetSpawnPosOnMouseClick();

        GameObject newDefender = Instantiate(Button.selectedDefender, spawnPos, Quaternion.identity) as GameObject;
        newDefender.transform.SetParent(defenderParent.transform);

        //Deduct spawned defender's star value from collection
        int starDeducted = newDefender.GetComponent<Defender>().GetStarValue();
        starController.DecreaseFromStarCollection(starDeducted);

    }

    private bool IsThereEnoughStarsToSpawn() {
        int starsLeft = StarController.GetStarCollection() - Button.selectedDefender.GetComponent<Defender>().GetStarValue();
        if (starsLeft < 0) {
            return false;            
        }

        return true;
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
