class DialogParser
{
	private Hero hero;

	public DialogParser(Hero hero)
	{
		this.hero = hero;
	}

	public string ParseDialog (IDialogPart part)
	{
		return part.GetDialogPartContent().Replace("#HERONAME#", hero.Name);
	}
}
