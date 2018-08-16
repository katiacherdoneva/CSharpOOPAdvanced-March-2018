public abstract class Gem : IGem
{
    private Clarity clarity;

    protected Gem()
    {
    }

    public int StrengthBonus { get; set; }

    public int AgilityBonus { get; set; }

    public int VitalityBonus { get; set; }

    public Clarity Clarity 
    {
        get { return clarity; }
        set
        {
            clarity = value;
            ChangeLevelClarity();
        }
    }

    public virtual void ChangeLevelClarity()
    {
        int n = (int)this.Clarity;

        this.StrengthBonus += n;
        this.AgilityBonus += n;
        this.VitalityBonus += n;
    }
}

