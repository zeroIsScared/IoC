using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IRegisterSpeaker
    {
         int? Register(Speaker speaker, IRepository repository);
         void ApproveRegistration(Speaker speaker);
         void CalculateRegistrationFee(Speaker speaker);
    }
}
