using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            SpawnSelectedDefender();
        }
    }

    private void SpawnSelectedDefender() {
        //Spawn position is the position of the mouse click, rounded to nearest int, in world space unit
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);        

        if (spawnPos.x > 9.5 || spawnPos.x < 0.5) {
            return;
        }
        if (spawnPos.y > 5.5 || spawnPos.y < 0.5) {
            return;
        }

        spawnPos.x = Mathf.RoundToInt(spawnPos.x);
        spawnPos.y = Mathf.RoundToInt(spawnPos.y);
        spawnPos.z = 0f;

        if (IsPositionFree(spawnPos)) {
            GameObject newDefender = Instantiate(Button.selectedDefender, spawnPos, Quaternion.identity) as GameObject;
            newDefender.transform.SetParent(transform);
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
