namespace DataAccessManager.Interface
{
    public interface ISocietyNominationRegister
    {
        Models.SocietyNominationRegister Add(Models.SocietyNominationRegister societyNominationRegister);

        Models.SocietyNominationRegister Update(Models.SocietyNominationRegister societyNominationRegister);
    }
}
