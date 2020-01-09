using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.TranslationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FacilityServices.DataLayer.Entities
{
    [Table("Floors")]
    public class FloorEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
