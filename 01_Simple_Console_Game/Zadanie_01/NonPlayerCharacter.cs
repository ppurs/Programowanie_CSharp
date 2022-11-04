class NonPlayerCharacter
{
	public string Name { get; }
	private NpcDialogPart npcDialogPart;

	public NonPlayerCharacter(string name, NpcDialogPart npcDialogPart)
	{
		this.Name = name;
		this.npcDialogPart = npcDialogPart;
	}

	public NpcDialogPart StartTalking()
	{
		return npcDialogPart;
	}
}
