using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook:BaseGradeBook
    {
        public StandardGradeBook(string name,bool isweighted):base(name,isweighted)
        {
            Type = Enums.GradeBookType.Standard;
        }
    }
}
