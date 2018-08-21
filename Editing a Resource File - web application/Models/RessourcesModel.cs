using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Editing_a_Resource_File___web_application.Models
{
    public class RessourcesModel
    {
        [Required]
        public String cmblanguages { get; set; }
        [Required]
        public String cmbressource { get; set; }
        [Required]
        public String cmbPages { get; set; }
    }
}