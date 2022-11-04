class NpcDialogPart : IDialogPart
{
    public List<HeroDialogPart>? heroParts { get; set; }
    private string partContent;

    public NpcDialogPart(string part)
	{
        partContent = part;
    }

    public string GetDialogPartContent()
    {
        return partContent;
    }
}
