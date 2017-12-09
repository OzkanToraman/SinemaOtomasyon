using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaOtomasyon.BLL.DTOs
{

    public class ResultModel<T>
        where T : class
    {
        public List<string> Errors { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
        T CurrentObject { get; set; }
    }

}
