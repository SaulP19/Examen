using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace AppMvc.Models
{
    public class PRODUCTOS
    {
    
            [Key]
            public string SKU { get; set; }
            public string MODELO { get; set; }
            public DateTime FECHA { get; set; }
            public string FERT { get; set; }
            public string NUMEROS { get; set; }
            public int TIPO { get; set; }

        
    }
}