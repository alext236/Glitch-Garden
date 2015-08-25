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
        Vector3 spawnPos = GetSpawnPosOnMouseClick();

        GameObject newDefender = Instantiate(Button.selectedDefender, spawnPos, Quaternion.identity) as GameObject;
        newDefender.transform.SetParent(defenderParent.transform);

    }

    private Vector3 GetSpawnPosOnMouseClick() {
        //Spawn position is the position of the mouse click, rounded to nearest int, in world space unit
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(spawnPos);

        spawnPos.x = Mathf.RoundToInt(spawnPos.x);
        spawnPos.y = Mathf.RoundToInt(spawnPos.y);
        spawnPos.z = 0f;

        return spawnPos;
    }
}
