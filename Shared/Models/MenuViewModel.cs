using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Core.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class MenuViewModel : Core.Data.Menu
    {
        public string ParentName { get; set; }
        [NotMapped]
        public List<SelectListItem> ListParent { get; set; }

    }
}
