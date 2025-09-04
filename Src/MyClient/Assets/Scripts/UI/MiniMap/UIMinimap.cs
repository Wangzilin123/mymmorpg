using Models;
using UnityEngine;
using UnityEngine.UI;

public class UIMinimap : MonoBehaviour
{
    public Image minimap;
    public Image arrow;
    public Text mapName;
    void Start()
    {
        this.mapName.text = User.Instance.CurrentMapData.Name;
    }

    void Update()
    {
        
    }
}
