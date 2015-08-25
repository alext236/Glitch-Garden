using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent;

    // Use this for initialization
    void Start() {
        defenderParent = GameObject.Find("Defender");
        if (defenderParent == null) {
            defenderParent = new GameObject("Defender");
        }
    }

    // Update is called once per frame
    void Update() {
                
    }

    public void OnMouseDown() {
        SpawnSelectedDefender();
    }

    private void SpawnSelectedDefender() {
        //Spawn position is the position of the mouse click, rounded to nearest int, in world space unit
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        spawnPos.x = Mathf.RoundToInt(spawnPos.x);
        spawnPos.y = Mathf.RoundToInt(spawnPos.y);
        spawnPos.z = 0f;

        if (IsPositionFree(spawnPos) == true) {
            GameObject newDefender = Instantiate(Button.selectedDefender, spawnPos, Quaternion.identity) as GameObject;
            newDefender.transform.SetParent(defenderParent.transform);
        }
    }

    private bool IsPositionFree(Vector3 position) {
        Defender[] existingDefenders = FindObjectsOfType<Defender>();
        foreach (Defender def in existingDefenders) {
            if (def.transform.position == position) {
                return false;
            }
        }

        return true;
    }
}
