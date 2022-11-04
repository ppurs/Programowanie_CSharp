class HeroDialogPart : IDialogPart
{
	public NpcDialogPart? NpcPart { set; get; }
	private string partContent;
	
	public HeroDialogPart(string part)
	{
		this.partContent = part;
	}

    public string GetDialogPartContent() { 
		return partContent;
	}
}
