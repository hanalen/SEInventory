/*
 * R e a d m e
 * -----------
 * 
 * In this file you can include any instructions or other comments you want to have injected onto the 
 * top of your final script. You can safely delete this file if you do not want any such comments.
 */

private int tickCount = 0;

List<string> listComponent = new List<string>();
List<string> listGas = new List<string>();
List<string> listIngot = new List<string>();
List<string> listOre = new List<string>();
List<string> listOther = new List<string>();
List<string> listTool = new List<string>();

public Program()
{
	Runtime.UpdateFrequency = UpdateFrequency.Once;
	listComponent.Add("MyObjectBuilder_Component/BulletproofGlass");
	listComponent.Add("MyObjectBuilder_Component/Canvas");
	listComponent.Add("MyObjectBuilder_Component/Computer");
	listComponent.Add("MyObjectBuilder_Component/Construction");
	listComponent.Add("MyObjectBuilder_Component/Detector");
	listComponent.Add("MyObjectBuilder_Component/Display");
	listComponent.Add("MyObjectBuilder_Component/Explosives");
	listComponent.Add("MyObjectBuilder_Component/Girder");
	listComponent.Add("MyObjectBuilder_Component/GravityGenerator");
	listComponent.Add("MyObjectBuilder_Component/InteriorPlate");
	listComponent.Add("MyObjectBuilder_Component/LargeTube");
	listComponent.Add("MyObjectBuilder_Component/Medical");
	listComponent.Add("MyObjectBuilder_Component/MetalGrid");
	listComponent.Add("MyObjectBuilder_Component/MetalGrid");
	listComponent.Add("MyObjectBuilder_Component/PowerCell");
	listComponent.Add("MyObjectBuilder_Component/RadioCommunication");
	listComponent.Add("MyObjectBuilder_Component/Reactor");
	listComponent.Add("MyObjectBuilder_Component/SmallTube");
	listComponent.Add("MyObjectBuilder_Component/SolarCell");
	listComponent.Add("MyObjectBuilder_Component/SteelPlate");
	listComponent.Add("MyObjectBuilder_Component/Superconductor");
	listComponent.Add("MyObjectBuilder_Component/Thrust");
	listComponent.Add("MyObjectBuilder_Component/ZoneChip");


	listGas.Add("MyObjectBuilder_GasProperties/Hydrogen");
	listGas.Add("MyObjectBuilder_GasProperties/Oxygen");

	listIngot.Add("MyObjectBuilder_Ingot/Cobalt");
	listIngot.Add("MyObjectBuilder_Ingot/Gold");
	listIngot.Add("MyObjectBuilder_Ingot/Stone");
	listIngot.Add("MyObjectBuilder_Ingot/Iron");
	listIngot.Add("MyObjectBuilder_Ingot/Magnesium");
	listIngot.Add("MyObjectBuilder_Ingot/Nickel");
	listIngot.Add("MyObjectBuilder_Ingot/Scrap");
	listIngot.Add("MyObjectBuilder_Ingot/Platinum");
	listIngot.Add("MyObjectBuilder_Ingot/Silicon");
	listIngot.Add("MyObjectBuilder_Ingot/Silver");
	listIngot.Add("MyObjectBuilder_Ingot/Uranium");

	listOre.Add("MyObjectBuilder_Ore/Cobalt");
	listOre.Add("MyObjectBuilder_Ore/Gold");
	listOre.Add("MyObjectBuilder_Ore/Stone");
	listOre.Add("MyObjectBuilder_Ore/Iron");
	listOre.Add("MyObjectBuilder_Ore/Magnesium");
	listOre.Add("MyObjectBuilder_Ore/Nickel");
	listOre.Add("MyObjectBuilder_Ore/Scrap");
	listOre.Add("MyObjectBuilder_Ore/Platinum");
	listOre.Add("MyObjectBuilder_Ore/Silicon");
	listOre.Add("MyObjectBuilder_Ore/Silver");
	listOre.Add("MyObjectBuilder_Ore/Uranium");

	listOther.Add("MyObjectBuilder_ConsumableItem/ClangCola");
	listOther.Add("MyObjectBuilder_ConsumableItem/CosmicCoffee");
	listOther.Add("MyObjectBuilder_Datapad/Datapad");
	listOther.Add("MyObjectBuilder_ConsumableItem/Medkit");
	listOther.Add("MyObjectBuilder_Package/Package");
	listOther.Add("MyObjectBuilder_ConsumableItem/Powerkit");
	listOther.Add("MyObjectBuilder_PhysicalObject/SpaceCredit");

	listTool.Add("MyObjectBuilder_PhysicalGunObject/AutomaticRifleItem");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/UltimateAutomaticRifleItem");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/AngleGrinder4Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/HandDrill4Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/Welder4Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/AngleGrinder2Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/HandDrill2Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/Welder2Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/AngleGrinderItem");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/HandDrillItem");
	listTool.Add("MyObjectBuilder_GasContainerObject/HydrogenBottle");
	listTool.Add("MyObjectBuilder_OxygenContainerObject/OxygenBottle");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/PreciseAutomaticRifleItem");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/AngleGrinder3Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/HandDrill3Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/Welder3Item");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/RapidFireAutomaticRifleItem");
	listTool.Add("MyObjectBuilder_PhysicalGunObject/WelderItem");
}

public void Save()
{
}

public void Main(string argument, UpdateType updateSource)
{
	//this.Light();
	InvenSort();

}

private void InvenSort()
{
	List<IMyCargoContainer> listCargo = new List<IMyCargoContainer>();
	GridTerminalSystem.GetBlocksOfType(listCargo);
	List<IMyCargoContainer> listBuffer = listCargo.FindAll(x => x.CustomName.IndexOf("buffer", StringComparison.OrdinalIgnoreCase) > -1);//buffer 추출
	listCargo = listCargo.FindAll(x => x.CustomName.IndexOf("buffer", StringComparison.OrdinalIgnoreCase) == -1);//buffer 제외
	if (listBuffer.Count == 0)
	{
		Echo("Not Exists Buffer Cargo!");
		return;
	}
	IMyCargoContainer buffer = listBuffer[0];
	SortCargo(buffer, listCargo, listComponent, "component");
	SortCargoDouble(buffer, listCargo, listIngot, "ingot");
	//SortCargo(buffer, listCargo, listOre, "ore");
	//SortCargo(buffer, listCargo, listTool, "tool");
	//SortCargo(buffer, listCargo, listOther, "other");
	//SortCargo(buffer, listCargo, listGas, "gas");
}

private bool CargoChanged()
{
	return false;
}

private void SortCargo(IMyCargoContainer buffer, List<IMyCargoContainer> listAllCargo, List<string> listTypes, string typeName)
{
	List<IMyCargoContainer> listComponentCargo = listAllCargo.FindAll(x => x.CustomName.IndexOf(typeName, StringComparison.OrdinalIgnoreCase) > -1);
	//Echo($"cargo count: {listComponentCargo.Count}");
	foreach (var itemType in listTypes)
	{
		int totalAmount = 0;
		foreach (var cargo in listAllCargo)//특정 아이템 buffer에 저장
		{
			List<MyInventoryItem> listMoveItem = new List<MyInventoryItem>();
			cargo.GetInventory().GetItems(listMoveItem);
			foreach (var item in listMoveItem)
			{
				if (item.Type.ToString() == itemType)
				{
					int a = 0;
					//Echo($"amount: {item.Amount.SerializeString()}");
					int.TryParse(item.Amount.SerializeString(), out a);
					totalAmount += a;
					MoveItem(cargo, buffer, item, item.Amount);
				}
			}
		}

		int moveAmount = totalAmount / listComponentCargo.Count;
		int moveCount = 0;
		//Echo($"tt c: {totalAmount}");
		//Echo($"mv c: {moveAmount}");
		//Echo($"cargo c: {listComponentCargo.Count}");

		foreach (var cargo in listComponentCargo)
		{
			MyInventoryItem? item = buffer.GetInventory().GetItemAt(0);
			if (!item.HasValue)
			{
				//Echo($"Inventory Item is null, type: {itemType}");
				continue;
			}
			moveCount++;
			if (moveCount == listComponentCargo.Count) moveAmount = totalAmount;//찌꺼기 안남게
			MoveItem(buffer, cargo, item.Value, moveAmount);
			totalAmount -= moveAmount;
		}
	}
}

private void SortCargoDouble(IMyCargoContainer buffer, List<IMyCargoContainer> listAllCargo, List<string> listTypes, string typeName)
{
	List<IMyCargoContainer> listComponentCargo = listAllCargo.FindAll(x => x.CustomName.IndexOf(typeName, StringComparison.OrdinalIgnoreCase) > -1);
	Echo($"cargo count: {listComponentCargo.Count}");
	foreach (var itemType in listTypes)
	{
		double totalAmount = 0;
		foreach (var cargo in listAllCargo)//특정 아이템 buffer에 저장
		{
			List<MyInventoryItem> listMoveItem = new List<MyInventoryItem>();
			cargo.GetInventory().GetItems(listMoveItem);
			foreach (var item in listMoveItem)
			{
				if (item.Type.ToString() == itemType)
				{
					double a = 0;
					Echo($"amount: {item.Amount.SerializeString()}");
					double.TryParse(item.Amount.SerializeString(), out a);
					totalAmount += a;
					MoveItem(cargo, buffer, item, item.Amount);
				}
			}
		}

		double moveAmount = totalAmount / listComponentCargo.Count;
		double moveCount = 0;
		Echo($"tt c: {totalAmount}");
		Echo($"mv c: {moveAmount}");
		Echo($"cargo c: {listComponentCargo.Count}");

		foreach (var cargo in listComponentCargo)
		{
			MyInventoryItem? item = buffer.GetInventory().GetItemAt(0);
			if (!item.HasValue)
			{
				//Echo($"Inventory Item is null, type: {itemType}");
				continue;
			}
			moveCount++;
			if (moveCount == listComponentCargo.Count) moveAmount = totalAmount;//찌꺼기 안남게
			MoveItem(buffer, cargo, item.Value, moveAmount);
			totalAmount -= moveAmount;
		}
	}
}

private void MoveItem(IMyCargoContainer from, IMyCargoContainer to, MyInventoryItem item, MyFixedPoint amount)
{
	from.GetInventory().TransferItemTo(to.GetInventory(), item, amount);
}

private void MoveItem(IMyCargoContainer from, IMyCargoContainer to, MyInventoryItem item, int amount)
{
	from.GetInventory().TransferItemTo(to.GetInventory(), item, amount);
}

private void MoveItem(IMyCargoContainer from, IMyCargoContainer to, MyInventoryItem item, double amount)
{
	from.GetInventory().TransferItemTo(to.GetInventory(), item, (MyFixedPoint)amount);
}