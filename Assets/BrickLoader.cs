using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLoader : MonoBehaviour
{
    [SerializeField]
    List<GameObject> levels = new List<GameObject>();
    [SerializeField]
    int currentlevelpattern;
    [SerializeField]
    GameObject currentLevelObject;
    private void Start()
    {
        LoadLevel();
    }
    public void LoadLevel()
    {
        if (currentlevelpattern >= levels.Count)
        {
            currentlevelpattern = 0;
        }
        if(currentLevelObject != null)
        {
            Destroy(currentLevelObject);
        }
        currentLevelObject = Instantiate(levels[currentlevelpattern]);
        currentlevelpattern++;
        currentLevelObject.transform.SetParent(transform);
    }
}
