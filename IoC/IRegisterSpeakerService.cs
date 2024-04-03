namespace BusinessLayer
{
    public interface IRegisterSpeakerService
    {
        int? Register(Speaker speaker, IRepository repository);
    }
}
