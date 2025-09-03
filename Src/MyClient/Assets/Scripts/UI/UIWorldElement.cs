using UnityEngine;

public class UIWorldElement : MonoBehaviour
{
    public Transform owner;

    [SerializeField] private float height =2f;

    void Start()
    {
        
    }

    void Update()
    {
        if (owner != null)
        {
            this.transform.position = owner.position+Vector3.up*height;
        }
    }
}
