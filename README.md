# Game-Dev-Group-Project

Script descriptions:
	Inventory.cs : Inventories are lists of items with getters and setters
	Item.cs : defines item class members and constructors
	ItemDatabase.cs : a singleton preserved between scenes that keeps track of item information. 
		has GetItem(int id) and GetItem(string name)
	OverWorldItem.cs : Contains logic to allow item to be collected by player
	OverWorldPlayer.cs : Player controls, picks up items, holds player inventory
	signpost.cs : Causes dialog to appear when player touches boxCollider

how to create new item:
	1. add entry to itemDatabase.cs buildDB method (itemID, Name, Description, Stats)
	2. add sprite to Assets/Resources/Items/ (note filename must be the same as item name from step 1)
	3. if collectable, copy existing item prefab from Assets/Prefabs/ and change sprite and itemID
