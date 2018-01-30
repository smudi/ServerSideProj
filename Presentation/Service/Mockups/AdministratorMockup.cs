using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Models;

namespace Service.Mockups
{
    public class AdministratorMockup
    {
        static public IEnumerable<Administrator> GetAdministrators()
        {
            return new List<Administrator>
            {
                new Administrator {Id=1, Name="Ebba Svensson", Information = "Programmer"},
                new Administrator {Id=2, Name = "Carolina Carlbom", Information ="Designer"}
            };
        }
    }
}