using Manager;
using Models;
using UnityEngine;
using UnityEngine.UI;

public class UIMinimap : MonoBehaviour
{
    public Collider minimapBoundingBox;
    public Image minimap;
    public Image arrow;
    public Text mapName;

    private Transform playerTransform;
    void Start()
    {
        InitMap();
    }


    void InitMap()
    {
        this.mapName.text = User.Instance.CurrentMapData.Name;
        this.minimap.overrideSprite = MinimapManager.Instance.LoadCurrentMinimap();

        this.minimap.SetNativeSize();
        this.minimap.transform.localScale = Vector3.one;


        //playerTransform=User.Instance.CurrentCharacterObject.transform;
    }

    void Update()
    {
        if (playerTransform == null && User.Instance.CurrentCharacterObject != null)
        {
            this.playerTransform = User.Instance.CurrentCharacterObject.transform;
        }

        float realWidth = minimapBoundingBox.bounds.size.x;
        float realHeight = minimapBoundingBox.bounds.size.z;

        float relaX = playerTransform.position.x - minimapBoundingBox.bounds.min.x;
        float relaY = playerTransform.position.z - minimapBoundingBox.bounds.min.z;

        float pivotX = relaX / realWidth;
        float pivoY = relaY / realHeight;

        this.minimap.rectTransform.pivot = new Vector2(pivotX, pivoY);
        this.minimap.rectTransform.localPosition = Vector2.zero;

        this.arrow.transform.eulerAngles = new Vector3(0,0,-playerTransform.eulerAngles.y);
    }
}
