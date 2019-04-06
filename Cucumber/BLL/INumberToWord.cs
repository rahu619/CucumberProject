using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cucumber.BLL
{
    public interface INumberToWord
    {
        string GetWords(double input);
    }
}