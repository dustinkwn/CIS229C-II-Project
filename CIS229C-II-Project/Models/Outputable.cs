using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS229C_II_Project.Models
{
    // Makes sure it has this method to return a string
    internal interface Outputable
    {
        // Like ToString (we have ToString at home; ToString at home:)
        string GetString();
    }
}
