using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT_Test.DCT.Services.Services
{
    public interface IConverter
    {
        double Convert(string FirstId, string LastId, double Quantity);
    }
}
