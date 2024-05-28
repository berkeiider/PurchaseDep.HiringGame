using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateObj : MonoBehaviour
{
    public Image PP;
    public Sprite[] temp;
    public GameObject parent;
    public Color[] colorList;
    public int colorNo;

    void Start()
    {
        for (int i = 0; i < temp.Length; i++)
        {
            var createImage = Instantiate(PP, parent.transform);
            createImage.color = colorList[colorNo];
            createImage.gameObject.SetActive(true);
            Image tempNew = createImage.GetComponentsInChildren<Image>()[1];
            tempNew.sprite = temp[i];
            createImage.gameObject.name = temp[i].name;

            // You can create prefabs if needed
            //string localPath = "Assets/UI button pack 3/Button round color " + (colorNo + 1).ToString() + "/" + createImage.gameObject.name + ".prefab";
            //CreateNew(createImage.gameObject, localPath);
        }
    }

    // This method is commented out as it is currently unused
    //static void CreateNew(GameObject obj, string localPath)
    //{
    //    //Create a new prefab at the path given
    //    GameObject prefab = PrefabUtility.SaveAsPrefabAsset(obj, localPath);
    //}
}
