class Location
{
	public string Name { get; }
	public List<NonPlayerCharacter> NpcList { get; }	

	public Location(string name, List<NonPlayerCharacter> npcList)
	{
		Name = name;
		NpcList = npcList;
	}
}
