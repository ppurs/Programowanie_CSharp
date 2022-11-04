enum EHeroClass
{
    Barbarzynca,
    Paladyn,
    Amazonka
}
class Hero
{
    public string Name { get; set; }
    public EHeroClass HeroType { get; set; }

    public Hero(string name)
    {
        this.Name = name;
    }

}
