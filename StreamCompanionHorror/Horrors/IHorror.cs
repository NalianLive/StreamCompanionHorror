namespace StreamCompanionHorror.Horrors
{
    internal interface IHorror
    {
        HorrorType GetHorrorType();
        void Execute();
    }
}
