using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class NumberSequenceManager
    {
        NumberSequenceGateway aNumberSequenceGateway = new NumberSequenceGateway();
        string successMessage = string.Empty;

        public string GetNumberSequence(string module)
        {
            string numberSequence = aNumberSequenceGateway.GetNumberSequence(module);
            return numberSequence;
        }

    }
}