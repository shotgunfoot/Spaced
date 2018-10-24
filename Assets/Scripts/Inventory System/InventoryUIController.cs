using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    public GameObject inventoryUI;
    
    [Required]
    public InventoryWithSlots playerInventory;
    [Required]
    public GameObject baseSlotPrefab;
    [Required]
    public UISlot backPackSprite;

    [InfoBox("These are anchors needed for UI generation")]
    [Required]
    public Transform baseMiscSlotAnchor;
    [Required]
    public Transform baseSmallSlotAnchor;
    [Required]
    public Transform baseLargeSlotAnchor;

    private List<UISlot> miscSlotSprites;
    private List<UISlot> smallSlotSprites;
    private List<UISlot> largeSlotSprites;

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        UpdateMiscSlots();
        UpdateBackpackSlot();
    }

    private void Start()
    {
        int miscSlots = playerInventory.miscSlotBaseCount;
        int smallSlots = playerInventory.smallSlotBaseCount;
        int largeSlots = playerInventory.largeSlotBaseCount;

        miscSlotSprites = new List<UISlot>();
        smallSlotSprites = new List<UISlot>();
        largeSlotSprites = new List<UISlot>();

        Vector3 offset;

        for (int i = 0; i < miscSlots; i++)
        {
            offset = new Vector3(i * 60, 0, 0);
            GameObject instance = Instantiate(baseSlotPrefab, baseMiscSlotAnchor);
            miscSlotSprites.Add(instance.GetComponentInChildren<UISlot>());
            instance.transform.localPosition += offset;
        }
        for (int i = 0; i < smallSlots; i++)
        {
            offset = new Vector3(i * 60, 0, 0);
            GameObject instance = Instantiate(baseSlotPrefab, baseSmallSlotAnchor);
            smallSlotSprites.Add(instance.GetComponentInChildren<UISlot>());
            instance.transform.localPosition += offset;
        }
        for (int i = 0; i < largeSlots; i++)
        {
            offset = new Vector3(i * 60, 0, 0);
            GameObject instance = Instantiate(baseSlotPrefab, baseLargeSlotAnchor);
            largeSlotSprites.Add(instance.GetComponentInChildren<UISlot>());
            instance.transform.localPosition += offset;
        }
    }

    public void UpdateMiscSlots()
    {
        for (int i = 0; i < playerInventory.miscSlots.Count; i++)
        {
            Item itemSprite = playerInventory.miscSlots[i].GetComponent<Item>();
            if (itemSprite != null)
            {
                miscSlotSprites[i].image.sprite = itemSprite.UISprite;
            }
        }
    }

    public void UpdateBackpackSlot()
    {
        backPackSprite.image.sprite = playerInventory.backpackContainer.UISprite;
    }
}


