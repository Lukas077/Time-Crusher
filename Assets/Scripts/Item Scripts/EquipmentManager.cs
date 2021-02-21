using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager _instance;

    void Awake()
    {
        _instance = this;
    }

    public Equipment[] defaultItems;
    public SkinnedMeshRenderer targetMesh;
    Equipment[] _currentEquipment;
    Inventory _inventory;
    private SkinnedMeshRenderer[] _currentMeshes;
    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged _onEquipmentChanged;

    void Start()
    {
        _inventory = Inventory._instance;

        int _numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;

        _currentEquipment = new Equipment[_numberOfSlots];
        _currentMeshes = new SkinnedMeshRenderer[_numberOfSlots];
        
        EquipDefaultItems();
        
        

    }

    public void Equip(Equipment newItem)
    {
        int _slotIndex = (int)newItem.equipSlot;
        Equipment _oldItem = Unequip(_slotIndex);


        if(_onEquipmentChanged != null)
        {
            _onEquipmentChanged.Invoke(newItem, _oldItem);
        }
        
        SetEquipmentBlendShapes(newItem, 100);

        _currentEquipment[_slotIndex] = newItem;
        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newItem.mesh);
        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;
        newMesh.rootBone = targetMesh.rootBone;
        _currentMeshes[_slotIndex] = newMesh;
    }

    public Equipment Unequip(int slotIndex)
    {
        if(_currentEquipment[slotIndex] != null)
        {
            if (_currentEquipment[slotIndex] != null)
            {
                Destroy(_currentMeshes[slotIndex].gameObject);
            }
            Equipment _oldItem = _currentEquipment[slotIndex];
            SetEquipmentBlendShapes(_oldItem, 0);
            _inventory.Add(_oldItem);

            _currentEquipment[slotIndex] = null;

            if (_onEquipmentChanged != null)
            {
                _onEquipmentChanged.Invoke(null, _oldItem);
            }
            return _oldItem;
        }

        return null;
    }

    public void UnequipAll()
    {
        for(int i = 0; i < _currentEquipment.Length; i++)
        {
            Unequip(i);
        }
        
        EquipDefaultItems();
    }

    void SetEquipmentBlendShapes(Equipment item, int weight)
    {
        foreach (EquipmentMeshRegion blendShape in item.coveredMeshRegions)
        {
            targetMesh.SetBlendShapeWeight((int)blendShape, weight);
            
        }
    }

    void EquipDefaultItems()
    {
        foreach (Equipment item in defaultItems)
        {
            Equip(item);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}
