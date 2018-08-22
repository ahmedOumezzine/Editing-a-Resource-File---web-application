using System;
using System.ComponentModel.DataAnnotations;

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