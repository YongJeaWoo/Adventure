using UnityEngine;

public class InventoryToggle : MouseLock
{
    private bool isOn = false;

    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private ItemInfoPanel itemInfoPanel;
    [SerializeField] private Transform inventoryCanvas;

    private void Update()
    {
        ToggleKeyButton();
    }

    private void ToggleKeyButton()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!isOn && PanelManager.instance.IsAnyPanelActive()) return;

            isOn = !isOn;
            inventoryCanvas.gameObject.SetActive(isOn);
            PanelManager.instance.SetPanelActive(isOn);

            if (isOn)
            {
                itemInfoPanel.ActiveUI.gameObject.SetActive(false);
                ShowMouseCursor();
            }
            else
            {
                HideMouseCursor();
                inventorySystem.InventoryUI.ItemAllDeSelect();
            }
        }
    }

    public void ToggleInventory(bool _state)
    {
        isOn = _state;
        inventoryCanvas.gameObject.SetActive(isOn);
        PanelManager.instance.SetPanelActive(isOn);

        if (isOn)
        {
            itemInfoPanel.ActiveUI.gameObject.SetActive(false);
            ShowMouseCursor();
        }
        else
        {
            HideMouseCursor();
        }
    }

    public void ExitButtonClick()
    {
        isOn = false;
        inventoryCanvas.gameObject.SetActive(false);
        PanelManager.instance.SetPanelActive(false);
        HideMouseCursor();
    }
}
