using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameRun : MonoBehaviour
{
    public List<GameObject> placeable;

    private float area;
    private float areaWin;
    private GameObject toPlace;
    private GameObject placing;
    private List<GameObject> placed;
    private List<string> placeableNames;
    private List<int> placeableAmounts;
    private UIController ui;

    private GameObject ToPlace
    {
        get
        {
            return toPlace;
        }

        set
        {
            if (value.GetComponent<PlaceableProperties>() != null)
            {
                string toPlaceName = value.GetComponent<PlaceableProperties>().placeableName;
                int nameIndex = placeableNames.IndexOf(toPlaceName);
                if (nameIndex > -1 && placeableAmounts[nameIndex] > 0)
                {
                    toPlace = value;
                    ui.updateCurrentPlaceable(value.GetComponent<PlaceableProperties>().placeableName);
                    return;
                }
            }
            ui.updateCurrentPlaceable("None");
            toPlace = null;
        }
    }

    private float Score
    {
        get
        {
            float score = 0;
            foreach (GameObject placeable in placed)
                if (placeable.GetComponent<PlaceableProperties>())
                    switch (placeable.GetComponent<PlaceableProperties>().placeableType)
                    {
                        case PlaceableProperties.Type.Sphere:
                            Transform transform = placeable.GetComponent<Transform>();
                            score += Mathf.PI * Mathf.Pow(transform.localScale.x, 2);
                            break;
                    }
            return score;
        }
    }

    void Awake()
    {
        if (this.GetComponent<UIController>())
        {
            ui = this.GetComponent<UIController>();
        }
        RunLevelDescriptor levelDescriptor = this.GetComponent<RunLevelDescriptor>();
        if (levelDescriptor)
        {
            placeableNames = levelDescriptor.placeableNames;
            placeableAmounts = levelDescriptor.placeableAmounts;
            areaWin = levelDescriptor.winArea;
        }
        placed = new List<GameObject>();
    }

    // Use this for initialization
    void Start()
    {
        ToPlace = placeable[0];
        ui.updateAvailablePlaceable(placeableNames, placeableAmounts);
        ui.updateScore(Score, areaWin);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ToPlace)
            {
                if (ToPlace.GetComponent<PlaceableProperties>() != null)
                {
                    string toPlaceName = ToPlace.GetComponent<PlaceableProperties>().placeableName;
                    int nameIndex = placeableNames.IndexOf(toPlaceName);
                    if (nameIndex > -1 && placeableAmounts[nameIndex] > 0)
                    {
                        var position = Input.mousePosition;
                        position = Camera.main.ScreenToWorldPoint(position);
                        placing = Instantiate(ToPlace);
                        placed.Add(placing);
                        placing.transform.position = new Vector3(position.x, position.y, 0);
                        placeableAmounts[nameIndex]--;
                        ui.updateAvailablePlaceable(placeableNames, placeableAmounts);
                        ToPlace = ToPlace;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (placing)
            {
                placing.GetComponent<CollisionScript>().FixInPlace();
            }
            placing = null;
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (placeable.Count >= 1)
                ToPlace = placeable[0];
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (placeable.Count >= 2)
                ToPlace = placeable[1];
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (placeable.Count >= 3)
                ToPlace = placeable[2];
        }
        ui.updateScore(Score, areaWin);

    }
}
