using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] Transform _itemHolder;

    private Item _holdingItem;

    private void OnTriggerEnter(Collider other)
    {
        Item item;
        if (other.TryGetComponent<Item>(out item))
        {
            item.LightOn(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(Input.GetMouseButtonDown(0))
        {
            Item item;
            if (other.TryGetComponent<Item>(out item))
            {
                item.gameObject.transform.SetParent(_itemHolder);
                item.gameObject.transform.localPosition = Vector3.zero;
                item.LightOn(false);
                _holdingItem = item;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Item item;
        if (other.TryGetComponent<Item>(out item))
        {
            item.LightOn(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_holdingItem != null)
            {
                _holdingItem.Drop();
                _holdingItem = null;
            }
        }
    }
}
