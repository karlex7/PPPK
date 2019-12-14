using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upravljanje_Flotom.DAL
{
    public class RepoFactory
    {
        public static IRepo GetRepo()
        {
            return new DBRepo();
        }
    }
}