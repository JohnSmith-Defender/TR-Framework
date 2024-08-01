using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItem : MonoBehaviour
{
    public string itemName;
    public bool destroyOnUse;

    public Sprite sprite;
    public GameObject inventoryModel;

    private PlayerInventory inventory;
    private PickItemCam pickItemCam;

    private void Start()
    {
        pickItemCam = FindObjectOfType<PickItemCam>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Action") && inventory == null)
            {
                inventory = other.gameObject.GetComponent<PlayerInventory>();
                Animator anim = other.gameObject.GetComponent<Animator>();
                anim.SetTrigger("PickUp");
                Invoke("PickedUp", 3f);
            }
        }
    }

    private void PickedUp()
    {
        inventory.AddItem(this);
        pickItemCam.SetAndEnable(gameObject);
        this.gameObject.SetActive(false);
        inventory = null;
    }

    public abstract void Use(PlayerController player);
}
