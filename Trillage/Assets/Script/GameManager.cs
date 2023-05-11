using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int gold;
    public TMPro.TMP_Text goldText;
    public int power;
    public TMPro.TMP_Text powerText;
    public int water;
    public TMPro.TMP_Text waterText;
    public string scene = "StartMenu";

    private Building buildingToPlace;
    public GameObject grid;

    public CustomCursor customCursor;

    public Tile[] tiles;

    


    private void Update()
    {
        goldText.text = gold.ToString();
        powerText.text = power.ToString();
        waterText.text = water.ToString();
        if(gold < 0 || power < 0 || water < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if(Input.GetMouseButtonDown(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            foreach(Tile tile in tiles)
            {
                float dist = Vector2.Distance(tile.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if(dist < nearestDistance)
                {
                    nearestDistance = dist;
                    nearestTile = tile;
                }
            }
            if(nearestTile.isOccupied == false)
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity);
                buildingToPlace = null;
                nearestTile.isOccupied = true;
                grid.SetActive(false);
                customCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    public void BuyBuilding(Building building)
    {
        if(gold >= building.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;

            gold -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }
    public void LandMark()
    {
        if(gold >= 100000)
        {
            SceneManager.LoadScene("Win");
        }
    }
}
